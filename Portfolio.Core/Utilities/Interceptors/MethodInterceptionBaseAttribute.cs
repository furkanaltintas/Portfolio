using Castle.DynamicProxy;

namespace Portfolio.Core.Utilities.Interceptors;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public int Priority { get; set; } // Çalışma sırası özelliği için

    public virtual void Intercept(IInvocation invocation)
    {

    }
}