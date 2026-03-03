using System;
using System.Diagnostics;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using NLog;

namespace Chummer
{
    /// <summary>
    /// Compatibility adapter so existing Application Insights wiring can continue to
    /// register an ITelemetryInitializer while telemetry is migrated to ActivitySource.
    /// Register this with TelemetryConfiguration.Initializers.
    /// </summary>
    public class ApplicationInsightsToActivityInitializer : ITelemetryInitializer
    {
        private static readonly Lazy<Logger> s_logger = new(() => LogManager.GetCurrentClassLogger());
        private static Logger Log => s_logger.Value;

        public void Initialize(ITelemetry telemetry)
        {
            try
            {
                var src = TelemetryManager.ActivitySource;
                using var activity = src.StartActivity("Chummer.TelemetryFromITelemetry", ActivityKind.Internal);
                if (activity == null)
                    return; // no listener attached

                // Map common Application Insights context fields to activity tags
                if (!string.IsNullOrEmpty(telemetry.Context.Operation.Id))
                    activity.SetTag("ai.operation.id", telemetry.Context.Operation.Id);
                if (!string.IsNullOrEmpty(telemetry.Context.Operation.ParentId))
                    activity.SetTag("ai.operation.parentId", telemetry.Context.Operation.ParentId);

                if (!string.IsNullOrEmpty(telemetry.Context.Cloud.RoleInstance))
                    activity.SetTag("cloud.role_instance", telemetry.Context.Cloud.RoleInstance);
                if (!string.IsNullOrEmpty(telemetry.Context.Cloud.RoleName))
                    activity.SetTag("cloud.role", telemetry.Context.Cloud.RoleName);

                if (!string.IsNullOrEmpty(telemetry.Context.User.Id))
                    activity.SetTag("enduser.id", telemetry.Context.User.Id);
                if (!string.IsNullOrEmpty(telemetry.Context.Session.Id))
                    activity.SetTag("session.id", telemetry.Context.Session.Id);
                if (!string.IsNullOrEmpty(telemetry.Context.InstrumentationKey))
                    activity.SetTag("instrumentation.key", telemetry.Context.InstrumentationKey);

                // Let the shared initializer apply the standard tags and allow plugins to enrich
                CustomTelemetryInitializer.Initialize(activity);
            }
            catch (Exception ex)
            {
                try { Log.Error(ex); } catch { }
            }
        }
    }
}
