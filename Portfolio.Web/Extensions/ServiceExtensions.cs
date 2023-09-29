using Autofac;
using Autofac.Extensions.DependencyInjection;
using Portfolio.Business.DependencyResolvers.Autofac;

namespace Portfolio.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static ConfigureHostBuilder ConfigureAutofac(this ConfigureHostBuilder host)
        {
            host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            }));

            return host;
        }
    }
}