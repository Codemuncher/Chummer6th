using System;
using Microsoft.ApplicationInsights.Extensibility;
using System.Runtime.CompilerServices;

namespace Chummer
{
    internal static class TelemetryAiAdapterRegistration
    {
        // Runs at module load to register the AI -> Activity adapter if Application Insights is present.
        [ModuleInitializer]
        public static void Initialize()
        {
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete - Using Active for backward compatibility with .NET Framework
                var config = TelemetryConfiguration.Active;
#pragma warning restore CS0618 // Type or member is obsolete
                if (config != null)
                {
                    // Avoid adding multiple times: check existing types
                    foreach (var init in config.TelemetryInitializers)
                    {
                        if (init is ApplicationInsightsToActivityInitializer)
                            return;
                    }

                    config.TelemetryInitializers.Add(new ApplicationInsightsToActivityInitializer());
                }
            }
            catch
            {
                // Telemetry is optional; swallow any errors.
            }
        }
    }
}
