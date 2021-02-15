using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandMenager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandMenager(IBrandDal brandDal)
        {
            _brandDal=brandDal;
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.GetSuccess);
        }

        public IDataResult<List<Brand>> GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>> ( _brandDal.GetAll(c => c.BrandId == brandId));
        }
    }
}
