using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.CrossCuttingConcerns.Caching;
using Portfolio.Core.Utilities.Interceptors;
using Portfolio.Core.Utilities.IoC;

namespace Portfolio.Core.Aspects.Autofac.Caching;

public class CacheRemoveAspect : MethodInterception
{
    private string _pattern;
    private ICacheManager _cacheManager;

    public CacheRemoveAspect(string pattern)
    {
        _pattern = pattern;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        _cacheManager.RemoveByPattern(_pattern);
    }
}