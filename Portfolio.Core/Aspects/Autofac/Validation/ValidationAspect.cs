using Castle.DynamicProxy;
using FluentValidation;
using Portfolio.Core.CrossCuttingConcerns.Validation;
using Portfolio.Core.Utilities.Interceptors;
using Portfolio.Core.Utilities.Messages;

namespace Portfolio.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) // Gönderilen validatorType, bir IValidator türünde değil ise
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator?)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator!, entity);
            }
        }
    }
}