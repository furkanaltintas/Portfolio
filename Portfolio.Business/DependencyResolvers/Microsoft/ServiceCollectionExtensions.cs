using Microsoft.Extensions.DependencyInjection;

namespace Portfolio.Business.DependencyResolvers.Microsoft
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ServiceExtensions(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddAutoMapper(typeof(Portfolio.Business.AssemblyRefence).Assembly);

            return services;

        }
    }
}