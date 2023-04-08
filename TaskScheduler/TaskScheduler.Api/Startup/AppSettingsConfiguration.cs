namespace TaskScheduler.Api.Startup
{
    public static class AppSettingsConfiguration
    {
        public static IHostBuilder ConfigureEnvironment(this IHostBuilder host)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if(environment != null) 
            {
                host.ConfigureAppConfiguration((ctx, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", false, true);
                    builder.AddJsonFile($"appsettings.{environment}.json, true, true");
                    builder.AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true);

                    builder.AddEnvironmentVariables();
                });
            }
            return host;
        }
    }
}
