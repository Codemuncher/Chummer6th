using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace Chummer
{
    public static class TelemetryService
    {
        // Track a page view, using Application Insights if available, otherwise fall back to OpenTelemetry Activity.
        public static void TrackPageView(string name, string id = null, IDictionary<string, string> properties = null, Uri url = null, TimeSpan? duration = null)
        {
            try
            {
                var aiClient = Program.ChummerTelemetryClient?.Value;
                if (aiClient != null)
                {
                    var pvt = new PageViewTelemetry(name)
                    {
                        Id = id ?? Guid.NewGuid().ToString(),
                        Name = name,
                        Timestamp = DateTimeOffset.UtcNow
                    };
                    if (url != null)
                        pvt.Url = url;
                    if (duration.HasValue)
                        pvt.Duration = duration.Value;
                    if (properties != null)
                    {
                        foreach (var kvp in properties)
                            pvt.Properties[kvp.Key] = kvp.Value;
                    }

                    aiClient.TrackPageView(pvt);
                    return;
                }

                // Fallback to Activity
                var activity = Program.StartActivity(name, ActivityKind.Internal);
                if (activity != null)
                {
                    if (properties != null)
                    {
                        foreach (var kvp in properties)
                            activity.SetTag(kvp.Key, kvp.Value);
                    }
                    if (url != null)
                        activity.SetTag("page.url", url.ToString());
                    if (duration.HasValue)
                        activity.SetTag("page.duration", duration.Value.TotalMilliseconds);
                    activity?.Stop();
                }
            }
            catch
            {
                // Swallow telemetry exceptions to avoid impacting app behavior
            }
        }

        public static void TrackException(Exception ex, IDictionary<string, string> properties = null)
        {
            try
            {
                var aiClient = Program.ChummerTelemetryClient?.Value;
                if (aiClient != null)
                {
                    var et = new ExceptionTelemetry(ex);
                    if (properties != null)
                    {
                        foreach (var kvp in properties)
                            et.Properties[kvp.Key] = kvp.Value;
                    }
                    aiClient.TrackException(et);
                    return;
                }

                var activity = Program.StartActivity("exception", ActivityKind.Internal);
                activity?.SetTag("exception.type", ex.GetType().FullName);
                activity?.SetTag("exception.message", ex.Message);
                activity?.Stop();
            }
            catch
            {
            }
        }
    }
}
