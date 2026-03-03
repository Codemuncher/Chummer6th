using System;
using System.Diagnostics;

namespace Chummer
{
    // Central telemetry manager providing a single ActivitySource and optional app-root Activity.
    internal static class TelemetryManager
    {
        private static readonly object s_lock = new object();
        private static ActivitySource? s_activitySource;
        private static Activity? s_rootActivity;

        // Expose a single ActivitySource for the application. Create on demand.
        public static ActivitySource ActivitySource
        {
            get
            {
                if (s_activitySource == null)
                {
                    lock (s_lock)
                    {
                        if (s_activitySource == null)
                        {
                            s_activitySource = new ActivitySource("Chummer", Utils.CurrentChummerVersion.ToString());
                        }
                    }
                }

                return s_activitySource!;
            }
        }

        // Initialize telemetry manager. Optionally start a long-lived root activity.
        public static void Initialize(bool startAppRootActivity = false)
        {
            // ensure ActivitySource is created
            _ = ActivitySource;

            if (startAppRootActivity)
            {
                StartAppRootActivity();
            }
        }

        // Start a persistent application root Activity. Safe to call multiple times.
        public static void StartAppRootActivity()
        {
            if (s_rootActivity != null)
                return;

            lock (s_lock)
            {
                if (s_rootActivity != null)
                    return;

                // Start a long-lived internal Activity to act as a parent for subsequent Activities.
                s_rootActivity = ActivitySource.StartActivity("Chummer.AppSession", ActivityKind.Internal);
                // Do not Dispose; keep it alive for lifetime of app until StopAppRootActivity is called.
            }
        }

        // Stop the persistent application root Activity, if any.
        public static void StopAppRootActivity()
        {
            lock (s_lock)
            {
                if (s_rootActivity == null)
                    return;

                try
                {
                    s_rootActivity.Stop();
                }
                finally
                {
                    s_rootActivity = null;
                }
            }
        }
    }
}
