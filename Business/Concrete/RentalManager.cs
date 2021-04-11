using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckCarIsAvailable(rental.CarId));
            if (result !=null)
            {
                return result;
            }
            
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddRentalMessage);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId ));
        }

        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.GetRentalsMessage);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalSummary);
        }

        public IResult RentalControl(int carId)
        {
            if (_rentalDal.Get(c => c.CarId == carId && c.ReturnDate == null) != null)
                return new ErrorResult(Messages.CarNotAvaible);
            else
                return new SuccessResult(Messages.GoToRent);
        }
        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == customerId));
        }


        //RentalMenager Business Rules
        private IResult CheckCarIsAvailable(int carId)
        {
            if (_rentalDal.Get(c => c.CarId == carId && c.ReturnDate == null ) != null)
                return new ErrorResult(Messages.CarNotAvaible);
            else
                return new SuccessResult();
        }

     
    }
}
