using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

      [ValidationAspect(typeof(CarValidator))] 
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckCarValidator(car));
            if (result!=null)
            {
                return result;
            }
             _carDal.Add(car);
              return new SuccessResult(Messages.CarAdded);
            
             
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
            
           
        } 

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.GetSuccess);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.GetSuccess);

        }

        public IDataResult<List<Car>> GetById(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.GetSuccess);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.BrandId==brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.ColorId==colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarFilter(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarFilter(brandId, colorId), Messages.CarListedByFilter);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
          return new SuccessResult(Messages.CarUpdated);
        }

        //Business Rules

        //1.Car Add Rules
        private IResult CheckCarValidator(Car car) 
        {
            if (car.BrandId == 0)
            {
                return new ErrorResult(Messages.ErrorBrandId);
            }
            if (car.ColorId == 0)
            {
                return new ErrorResult(Messages.ErrorColorId);
            }
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.ErrorDailyPrice);
            }
            if(car.BrandId==0 && car.DailyPrice <= 250)
            {
                return new ErrorResult(Messages.ErrorDailyPriceForBrandId);
            }
            return new SuccessResult(null);
        }
    }
}
