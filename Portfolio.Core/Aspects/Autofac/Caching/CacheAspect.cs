using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.CrossCuttingConcerns.Caching;
using Portfolio.Core.Utilities.Interceptors;
using Portfolio.Core.Utilities.IoC;

namespace Portfolio.Core.Aspects.Autofac.Caching;

public class CacheAspect : MethodInterception
{
    private readonly int _duration;
    private readonly ICacheManager _cacheManager;

    public CacheAspect(int duration = 60) // default 60 dakika
    {
        _duration = duration;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    public override void Intercept(IInvocation invocation)
    {
        // invocation.Method.ReflectedType.FullName => CLASS ismi, invocation.Method.Name => METOT ismi
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments.ToList();
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // Örnek: SkillManager.GetBySill(1, net)

        if (_cacheManager.IsAdd(key)) // Daha önce cache yapısına böyle bir key eklenmişse
        {
            // Metodu hiç çalıştırma, o metodun value değerini cache üzerinden al
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }

        // Cache içerisinde yok ise burası çalışacak
        invocation.Proceed();
        _cacheManager.Add(key, invocation.ReturnValue, _duration);
    }
}