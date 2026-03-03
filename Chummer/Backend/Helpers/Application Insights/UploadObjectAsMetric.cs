/*  This file is part of Chummer5a.
 *
 *  Chummer5a is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Chummer5a is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Chummer5a.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  You can obtain the full source code for Chummer5a at
 *  https://github.com/chummer5a/chummer5a
 */

using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Metrics;

namespace Chummer
{
    public static class UploadObjectAsMetric    
    {
        [CLSCompliant(false)]
        public static bool UploadObject(TelemetryClient tc, object obj)
        {
            ArgumentNullException.ThrowIfNull(tc);
            ArgumentNullException.ThrowIfNull(obj);

            PropertyInfo[] allProperties;
            string name;
            if (obj is Type objAsType)
            {
                allProperties = objAsType.GetProperties();
                name = objAsType.Name;
            }
            else
            {
                allProperties = obj.GetType().GetProperties();
                name = obj.ToString();
            }

            // keep original behaviour for TelemetryClient
            MetricIdentifier micount = new MetricIdentifier(name, "MetricsReportCount");
            Metric mcount = tc.GetMetric(micount);
            mcount.TrackValue(1);

            foreach (PropertyInfo prop in allProperties.Where(x => x.PropertyType == typeof(bool)))
            {
                object val = prop.GetValue(obj, null);
                Console.WriteLine("{0}={1}", prop.Name, val);
                if (!bool.TryParse(val?.ToString(), out bool boolval))
                    continue;
                MetricIdentifier mi = new MetricIdentifier(name, prop.Name);
                Metric metric = tc.GetMetric(mi);
                // Avoid ambiguous extension method by using inline conditional
                metric.TrackValue(boolval ? 1 : 0);
            }

            return true;
        }

        // New overload: use ActivitySource + Meter (ActiveSource approach)
        // If caller passes null for meter, a short-lived Meter will be created.
        // Prefer creating and re-using a Meter and ActivitySource at application scope.
        public static bool UploadObject(ActivitySource activitySource, Meter meter, object obj)
        {
            if (activitySource == null)
                throw new ArgumentNullException(nameof(activitySource));
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            PropertyInfo[] allProperties;
            string name;
            if (obj is Type objAsType)
            {
                allProperties = objAsType.GetProperties();
                name = objAsType.Name;
            }
            else
            {
                allProperties = obj.GetType().GetProperties();
                // fallback to type name to form stable metric names
                name = obj.GetType().Name;
            }

            bool createdTemporaryMeter = false;
            if (meter == null)
            {
                meter = new Meter("Chummer.Metrics", "1.0.0"); // short-lived fallback
                createdTemporaryMeter = true;
            }

            // Counters: increment 1 for MetricsReportCount
            var countCounter = meter.CreateCounter<long>($"{name}.MetricsReportCount");
            countCounter.Add(1);

            // Start an Activity for context (optional, useful for traces)
            using (var activity = activitySource.StartActivity($"{name}.UploadMetrics", ActivityKind.Internal))
            {
                if (activity != null)
                {
                    activity.SetTag("chummer.metric.reportedTime", DateTimeOffset.UtcNow.ToString("o"));
                }

                foreach (PropertyInfo prop in allProperties.Where(x => x.PropertyType == typeof(bool)))
                {
                    object val = prop.GetValue(obj, null);
                    Console.WriteLine("{0}={1}", prop.Name, val);

                    if (!bool.TryParse(val?.ToString(), out bool boolval))
                        continue;

                    // record boolean as 0/1 on a counter
                    var propCounter = meter.CreateCounter<long>($"{name}.{prop.Name}");
                    propCounter.Add(boolval ? 1 : 0);

                    // optionally add as Activity tag for correlation
                    activity?.SetTag(prop.Name, boolval);
                }
            }

            // Dispose short-lived meter if we created it here.
            if (createdTemporaryMeter)
            {
                (meter as IDisposable)?.Dispose();
            }

            return true;
        }

        // Convenience overload: only ActivitySource and object (uses internal fallback meter)
        public static bool UploadObject(ActivitySource activitySource, object obj) =>
            UploadObject(activitySource, null, obj);
    }
}
