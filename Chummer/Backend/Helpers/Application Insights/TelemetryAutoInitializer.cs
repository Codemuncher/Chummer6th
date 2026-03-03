using System;
using System.Runtime.CompilerServices;

namespace Chummer
{
    // Automatically initialize telemetry at module load. This avoids modifying Program.cs directly
    // and ensures the ActivitySource and optional app-root Activity are created early.
    internal static class TelemetryAutoInitializer
    {
        [ModuleInitializer]
        public static void InitializeModule()
        {
            try
            {
                // Start app-root Activity by default. Change to false if you prefer not to start it automatically.
                TelemetryBootstrap.InitializeAtStartup(startAppRootActivity: true);

                // Ensure we stop the root Activity on process exit
                AppDomain.CurrentDomain.ProcessExit += (_, __) => TelemetryBootstrap.Shutdown();
            }
            catch
            {
                // Never throw from a module initializer
            }
        }
    }
}
