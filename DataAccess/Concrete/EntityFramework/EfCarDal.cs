using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarDal:EfEntityRepositoryBase<Car,SqlCarContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car,bool>>filter=null)
        {
            using (SqlCarContext context = new SqlCarContext())
            {
                var result = from c in filter==null ? context.Cars:context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join o in context.Colors on c.ColorId equals o.ColorId
                             join i in context.Images on c.Id equals i.CarId
                             select new CarDetailDto 
                             { CarId=c.Id, 
                               BrandName = b.BrandName,
                               ColorName = o.ColorName, 
                               DailyPrice = c.DailyPrice,
                               BrandId=c.BrandId,
                               ColorId=c.ColorId,
                               Description=c.Description,
                               ModelYear=c.ModelYear, 
                               CarName=c.CarName,
                               ImagePath=i.ImagePath
                             };
                return result.ToList();
            }
        }
    }
}
