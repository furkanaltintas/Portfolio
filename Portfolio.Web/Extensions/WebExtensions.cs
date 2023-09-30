namespace Portfolio.Web.Extensions;

public static class WebExtensions
{
    public static void StartupExtensions(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
    {
        services.ConfigureControllers();

        host.ConfigureAutofac();

        services.ConfigureDbContext(configuration);

        services.ConfigureIdentity();

        services.ConfigureCookie();

        services.ConfigureSession();
    }
}