using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,ColorId=1,BrandId=1,ModelYear="2016",DailyPrice=68000,Description="Güç (b.g.)=136"},
                new Car{Id=2,ColorId=2,BrandId=6,ModelYear="2010",DailyPrice=48000,Description="Güç (b.g.)=116"},
                new Car{Id=3,ColorId=2,BrandId=2,ModelYear="2014",DailyPrice=62000,Description="Güç (b.g.)=116"},
                new Car{Id=4,ColorId=1,BrandId=5,ModelYear="2011",DailyPrice=69000,Description="Güç (b.g.)=150"},
                new Car{Id=5,ColorId=3,BrandId=4,ModelYear="2011",DailyPrice=61430,Description="Güç (b.g.)=116"},
                new Car{Id=6,ColorId=3,BrandId=3,ModelYear="2019",DailyPrice=91220,Description="Güç (b.g.)=190"},
                new Car{Id=7,ColorId=4,BrandId=1,ModelYear="2015",DailyPrice=180000,Description="Güç (b.g.)=231"},
                new Car{Id=8,ColorId=4,BrandId=1,ModelYear="2015",DailyPrice=180000,Description="Güç (b.g.)=231"},
                new Car{Id=9,ColorId=3,BrandId=1,ModelYear="2019",DailyPrice=80000,Description="Güç (b.g.)=231"},
                new Car{Id=10,ColorId=1,BrandId=5,ModelYear="2011",DailyPrice=80100,Description="Güç (b.g.)=116"},
                new Car{Id=11,ColorId=1,BrandId=4,ModelYear="2017",DailyPrice=180100,Description="Güç (b.g.)=231"},
                new Car{Id=12,ColorId=2,BrandId=4,ModelYear="2012",DailyPrice=120000,Description="Güç (b.g.)=190"},
                new Car{Id=13,ColorId=1,BrandId=4,ModelYear="2010",DailyPrice=150000,Description="Güç (b.g.)=231"},
                new Car{Id=14,ColorId=2,BrandId=4,ModelYear="2005",DailyPrice=120000,Description="Güç (b.g.)=231"},
                new Car{Id=15,ColorId=2,BrandId=2,ModelYear="2014",DailyPrice=190000,Description="Güç (b.g.)=300"},
                new Car{Id=16,ColorId=3,BrandId=1,ModelYear="2011",DailyPrice=220000,Description="Güç (b.g.)=300"},
                new Car{Id=17,ColorId=4,BrandId=4,ModelYear="2015",DailyPrice=110000,Description="Güç (b.g.)=231"}


            };

            _brands = new List<Brand>
            {new Brand{BrandId=1,BrandName="BMV"},
            new Brand{BrandId=2,BrandName="Mercedes"},
            new Brand{BrandId=3,BrandName="Audi"},
            new Brand{BrandId=4,BrandName="Toyota"},
            new Brand{BrandId=5,BrandName="Fiat"},
            new Brand{BrandId=6,BrandName="Renault"},



            };
        
        
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarFilter(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
