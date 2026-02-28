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
using System.Diagnostics;
using Chummer.Plugins;
using System.Reflection;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using NLog;

namespace Chummer
{
    // This class supports both Application Insights' ITelemetryInitializer (for existing
    // TelemetryClient/TelemetryConfiguration usage) and OpenTelemetry-style enrichment
    // via Activity. That allows gradual migration.
    public class CustomTelemetryInitializer : ITelemetryInitializer
    {
        private static readonly Lazy<Logger> s_ObjLogger = new Lazy<Logger>(LogManager.GetCurrentClassLogger);
        private static Logger Log => s_ObjLogger.Value;

        // Set session data:
        //private static string Hostname =  Dns.GetHostName();

        [CLSCompliant(false)]
        // OpenTelemetry-style initializer
        public void Initialize(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            // Add a milestone/global property
            activity.SetTag("app.milestone", Utils.IsMilestoneVersion.ToString(GlobalSettings.InvariantCultureInfo));

            // Device / OS information
            activity.SetTag("os.description", Environment.OSVersion.ToString());

            if (Properties.Settings.Default.UploadClientId == Guid.Empty
                //sometimes, there are odd values stored in the UploadClientId.
                || !Properties.Settings.Default.UploadClientId.ToString().IsGuid())
            {
                Properties.Settings.Default.UploadClientId = Guid.NewGuid();
                Properties.Settings.Default.Save();
            }

            var uploadId = Properties.Settings.Default.UploadClientId.ToString();
            activity.SetTag("cloud.role_instance", uploadId);
            activity.SetTag("cloud.role", uploadId);
            activity.SetTag("device.id", Environment.MachineName);
            activity.SetTag("session.id", uploadId);
            activity.SetTag("enduser.id", uploadId);

            activity.SetTag("service.version", Utils.CurrentChummerVersion.ToString());

            if (Debugger.IsAttached)
            {
                //don't fill the "productive" logs with garbage from debug sessions
                activity.SetTag("instrumentation.key", "f4b2ea1b-afe4-4bd6-9175-f5bb167a4d8b");
            }

            // Allow plugins to further enrich the Activity. Plugins may implement a
            // SetTelemetryInitialize method that accepts an Activity; call it via reflection
            // so we remain compatible even if plugin implementations vary.
            foreach (IPlugin plugin in Program.PluginLoader.MyActivePlugins)
            {
                try
                {
                    // Prefer a plugin method that accepts Activity
                    var method = plugin.GetType().GetMethod("SetTelemetryInitialize", new[] { typeof(Activity) });
                    if (method != null)
                    {
                        method.Invoke(plugin, new object[] { activity });
                    }
                    else
                    {
                        // fallback: try any method named SetTelemetryInitialize with a single parameter
                        var methods = plugin.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        foreach (var m in methods)
                        {
                            if (m.Name == "SetTelemetryInitialize" && m.GetParameters().Length == 1)
                            {
                                var paramType = m.GetParameters()[0].ParameterType;
                                if (paramType.IsAssignableFrom(typeof(Activity)))
                                {
                                    m.Invoke(plugin, new object[] { activity });
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    e = e.Demystify();
                    Log.Error(e);
#if DEBUG
                    throw;
#endif
                }
            }
        }

        // Backwards-compatible Application Insights initializer. This allows the existing
        // TelemetryConfiguration/TelemetryClient setup in Program.cs to continue working.
        public void Initialize(ITelemetry telemetry)
        {
            if (telemetry == null)
                throw new ArgumentNullException(nameof(telemetry));

            // Milestone/global property
            if (telemetry.Context.GlobalProperties.ContainsKey("Milestone"))
                telemetry.Context.GlobalProperties["Milestone"] = Utils.IsMilestoneVersion.ToString(GlobalSettings.InvariantCultureInfo);
            else
                telemetry.Context.GlobalProperties.Add("Milestone", Utils.IsMilestoneVersion.ToString(GlobalSettings.InvariantCultureInfo));

            telemetry.Context.Device.OperatingSystem = Environment.OSVersion.ToString();

            if (Properties.Settings.Default.UploadClientId == Guid.Empty
                //sometimes, there are odd values stored in the UploadClientId.
                || !Properties.Settings.Default.UploadClientId.ToString().IsGuid())
            {
                Properties.Settings.Default.UploadClientId = Guid.NewGuid();
                Properties.Settings.Default.Save();
            }

            var uploadId = Properties.Settings.Default.UploadClientId.ToString();
            telemetry.Context.Cloud.RoleInstance = uploadId;
            telemetry.Context.Cloud.RoleName = uploadId;
            telemetry.Context.Device.Id = Environment.MachineName;
            telemetry.Context.Session.Id = uploadId;
            telemetry.Context.User.Id = uploadId;

            telemetry.Context.Component.Version = Utils.CurrentChummerVersion.ToString();

            if (Debugger.IsAttached)
            {
                //don't fill the "productive" log with garbage from debug sessions
                telemetry.Context.InstrumentationKey = "f4b2ea1b-afe4-4bd6-9175-f5bb167a4d8b";
            }

            // Allow plugins to further enrich the telemetry; try plugin methods that accept ITelemetry
            foreach (IPlugin plugin in Program.PluginLoader.MyActivePlugins)
            {
                try
                {
                    var method = plugin.GetType().GetMethod("SetTelemetryInitialize", new[] { typeof(ITelemetry) });
                    if (method != null)
                    {
                        method.Invoke(plugin, new object[] { telemetry });
                        continue;
                    }

                    // fallback to Activity-based plugin methods by creating a temporary Activity
                    var activity = new Activity("Chummer.TempTelemetryEnrichment");
                    activity.Start();
                    Initialize(activity);
                    activity.Stop();

                    // If plugin only supports Activity, attempt to call that method
                    method = plugin.GetType().GetMethod("SetTelemetryInitialize", new[] { typeof(Activity) });
                    if (method != null)
                    {
                        method.Invoke(plugin, new object[] { activity });
                    }
                }
                catch (Exception e)
                {
                    e = e.Demystify();
                    Log.Error(e);
#if DEBUG
                    throw;
#endif
                }
            }
        }
    }
}
