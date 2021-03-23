using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(IFormFile file, Image image)
        {
            var result = BusinessRules.Run(CheckCarImageLimitExeeded(image.CarId));
            if (result!=null)
            {
                return result;
            }
            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Delete(Image image)
        {
            FileHelper.Delete(image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult(Messages.ImageDeleted);
        }
       
        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i=>i.CarId==carId));
        }

        public IDataResult<Image> GetById(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(i=>i.Id==id));
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Update(IFormFile file, Image image)
        {
            image.ImagePath = FileHelper.Update(_imageDal.Get(i => i.Id == image.Id).ImagePath, file);
            image.Date = DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult(Messages.ImageUpdated);
        }

        //BusinessRules
        private IResult CheckCarImageLimitExeeded(int carId)
        {
            if (_imageDal.GetAll(c=>c.CarId==carId).Count>=5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }

}
