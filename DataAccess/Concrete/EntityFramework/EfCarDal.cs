using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarDal:EfEntityRepositoryBase<Car,SqlCarContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (SqlCarContext context = new SqlCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join o in context.Colors on c.ColorId equals o.ColorId
                             select new CarDetailDto { BrandName = b.BrandName,  ColorName = o.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
