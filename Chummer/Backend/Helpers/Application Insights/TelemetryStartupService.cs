using System;
using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Resources;

namespace Chummer
{
    public static class TelemetryStartupService
    {
        private static ActivitySource s_activitySource;
        private static TracerProvider s_tracerProvider;

        public static ActivitySource ActivitySource => s_activitySource ??= new ActivitySource("Chummer5");

        public static TracerProvider TracerProvider => s_tracerProvider;

        public static void Initialize(string connectionString)
        {
            if (s_tracerProvider != null)
                return; // already initialized

            s_activitySource ??= new ActivitySource("Chummer5");

            var builder = Sdk.CreateTracerProviderBuilder()
                .AddSource("Chummer5")
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Chummer5", serviceVersion: Utils.CurrentChummerVersion.ToString()))
                .AddAzureMonitorTraceExporter(o => o.ConnectionString = connectionString);

            s_tracerProvider = builder.Build();
        }

        public static void Shutdown()
        {
            try
            {
                s_tracerProvider?.Dispose();
                s_tracerProvider = null;
            }
            catch
            {
            }
        }
    }
}
