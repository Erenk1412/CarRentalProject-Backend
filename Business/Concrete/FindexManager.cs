using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindexManager : IFindexService
    {
        IFindexDal _findexDal;
        public FindexManager(IFindexDal findexDal)
        {
            _findexDal = findexDal;
        }
        public IDataResult <Findex> GetFindexByUserId(int userId)
        {
            return new SuccessDataResult<Findex>(_findexDal.Get(p => p.UserId == userId));
        }
    }
}
