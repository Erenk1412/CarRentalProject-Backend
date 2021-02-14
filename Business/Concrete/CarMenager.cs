using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarMenager : ICarService
    {
        ICarDal _carDal;

        public CarMenager(ICarDal carDal)
        {
            _carDal = carDal;
        }

       
        public void Add(Car car)
        {
           
           
            if (car.BrandId==0)
            {
                Console.WriteLine("Error message");
            }
            else
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            
            
           
        } 

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return new List<Car>(_carDal.GetAll(c => c.BrandId == brandId));
            
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return new List<CarDetailDto>(_carDal.GetCarDetails());
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
