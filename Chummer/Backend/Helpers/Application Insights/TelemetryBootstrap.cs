using System;

namespace Chummer
{
    /// <summary>
    /// Simple bootstrap helper to initialize application telemetry in a single call.
    /// Call from Program.Main early in startup.
    /// </summary>
    internal static class TelemetryBootstrap
    {
        /// <summary>
        /// Initialize telemetry subsystem and optionally start a long-lived root activity.
        /// This method is safe to call multiple times.
        /// </summary>
        /// <param name="startAppRootActivity">If true, a persistent app-root Activity will be created and kept alive until StopAppRootActivity is called.</param>
        public static void InitializeAtStartup(bool startAppRootActivity = false)
        {
            try
            {
                TelemetryManager.Initialize(startAppRootActivity);

                // Enrich initial telemetry using the existing initializer
                CustomTelemetryInitializer.Initialize(TelemetryManager.ActivitySource);
            }
            catch (Exception ex)
            {
                try { NLog.LogManager.GetCurrentClassLogger().Error(ex); } catch { }
            }
        }

        /// <summary>
        /// Stops the app-root activity if one was started.
        /// </summary>
        public static void Shutdown()
        {
            try
            {
                TelemetryManager.StopAppRootActivity();
            }
            catch (Exception ex)
            {
                try { NLog.LogManager.GetCurrentClassLogger().Error(ex); } catch { }
            }
        }
    }
}
