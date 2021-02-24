using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
  public class ValidationAspect:MethodInterception

    {
        private Type _validatorType;
        public ValidationAspect(Type validatortype)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatortype))
            {
                throw new System.Exception("Bu bir dogrulama sinifi degildir");
            }

            _validatorType = validatortype;
        }

    }
}
