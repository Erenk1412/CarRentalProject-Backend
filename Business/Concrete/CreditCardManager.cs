using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard card)
        {
            _creditCardDal.Add(card);
            return new SuccessResult(Messages.CardAdded);
        }

        public IDataResult<CreditCard> GetByCustomerId(int id)
        {
            var result = _creditCardDal.Get(card => card.CustomerId == id);
            return new SuccessDataResult<CreditCard>(result);
        }
    }
}
