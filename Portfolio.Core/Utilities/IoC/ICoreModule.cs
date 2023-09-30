using Microsoft.Extensions.DependencyInjection;

namespace Portfolio.Core.Utilities.IoC;

public interface ICoreModule
{
    void Load(IServiceCollection services);
}