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
// ApplicationInsights types removed in favor of Activity/ActivitySource based initialization
using NLog;

namespace Chummer
{
    // This class supports both Application Insights' ITelemetryInitializer (for existing
    // TelemetryClient/TelemetryConfiguration usage) and OpenTelemetry-style enrichment
    // via Activity. That allows gradual migration.
    public class CustomTelemetryInitializer
    {
        private static readonly Lazy<Logger> s_ObjLogger = new Lazy<Logger>(LogManager.GetCurrentClassLogger);
        private static Logger Log => s_ObjLogger.Value;

        // Set session data:
        //private static string Hostname =  Dns.GetHostName();

        [CLSCompliant(false)]
        // OpenTelemetry-style initializer
        public static void Initialize(Activity activity)
        {
            ArgumentNullException.ThrowIfNull(activity);

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

        // ActivitySource-based initializer. Use this to enrich OpenTelemetry/Activity flows
        // and to provide a migration path away from Application Insights' ITelemetry.
        public static void Initialize(ActivitySource activitySource)
        {
            ArgumentNullException.ThrowIfNull(activitySource);

            using var activity = activitySource.StartActivity("Chummer.TelemetryInitialization", ActivityKind.Internal);
            if (activity == null)
                return; // no listener is attached

            // Delegate to the Activity-based initializer which sets tags and allows plugins
            Initialize(activity);
        }
    }
}
