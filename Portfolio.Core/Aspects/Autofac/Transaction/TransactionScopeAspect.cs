using Castle.DynamicProxy;
using Portfolio.Core.Utilities.Interceptors;
using System.Transactions;

namespace Portfolio.Core.Aspects.Autofac.Transaction;

public class TransactionScopeAspect : MethodInterception
{
    public override void Intercept(IInvocation invocation)
    {
        using (TransactionScope transactionScope = new())
        {
            try
            {
                invocation.Proceed();
                transactionScope.Complete(); // İşlemi kabul et
            }
            catch (Exception e)
            {
                transactionScope.Dispose(); // Yapılan işlemleri geri al
                throw;
            }
        }
    }
}