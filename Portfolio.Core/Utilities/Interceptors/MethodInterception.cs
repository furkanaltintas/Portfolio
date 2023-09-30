using Castle.DynamicProxy;

namespace Portfolio.Core.Utilities.Interceptors;

public abstract class MethodInterception : MethodInterceptionBaseAttribute
{
    // invocation: Aslında bizim metodumuz. Çalıştırılmaya çalışılan metot.

    protected virtual void OnBefore(IInvocation invocation) { }
    protected virtual void OnAfter(IInvocation invocation) { }
    protected virtual void OnException(IInvocation invocation) { }
    protected virtual void OnSuccess(IInvocation invocation) { }

    public override void Intercept(IInvocation invocation)
    {
        bool isSuccess = true;

        OnBefore(invocation);

        try
        {
            invocation.Proceed(); // Operasyonu yani metodu çalıştır anlamına gelir
        }
        catch (Exception e)
        {
            isSuccess = false;
            OnException(invocation);
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                OnSuccess(invocation);
            }
        }

        OnAfter(invocation);
    }
}