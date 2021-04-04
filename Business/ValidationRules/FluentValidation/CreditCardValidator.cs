using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(card => card.CustomerId).NotEmpty();

            RuleFor(card => card.CardNumber).NotEmpty();
            RuleFor(card => card.CardNumber).Length(16);

            RuleFor(card => card.CustomerNameAndSurname).NotEmpty();

            RuleFor(card => card.CVV).NotEmpty();
            RuleFor(card => card.CVV).Length(3);

            RuleFor(card => card.DateMonth).NotEmpty();
            RuleFor(card => card.DateYear).NotEmpty();


        }

    }
}
