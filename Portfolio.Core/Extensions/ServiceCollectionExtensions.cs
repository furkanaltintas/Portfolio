using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Utilities.IoC;

namespace Portfolio.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
    {
        foreach (var module in modules)
        {
            module.Load(services); // Bütün modülleri ekledik
        }

        return ServiceTool.Create(services);
    }
}