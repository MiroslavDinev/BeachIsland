namespace BeachIsland.Server.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static AppSettings GetAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsConfiguration = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsConfiguration);
            var appSettings = appSettingsConfiguration.Get<AppSettings>();

            return appSettings;
        }
    }
}
