using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.BrandId).NotEqual(0);
            RuleFor(c => c.ColorId).NotEqual(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(60000).When(c=>c.BrandId==1);

        }
    }
}
