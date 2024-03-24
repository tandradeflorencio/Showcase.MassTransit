using Serilog;

namespace Showcase.MassTransit.Configurations
{
    internal static class LogConfiguration
    {
        public static void ConfigureLogs(this IServiceCollection services, ConfigurationManager configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("Showcase.MassTransit", "Showcase.MassTransit")
                .CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}