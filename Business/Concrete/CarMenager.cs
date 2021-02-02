using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
            _carDal.Add(car);
            Console.WriteLine("Aracin Brandl Id'sini belirleyin:");
            int BrandlId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracın BrandId'sini belirleyin: ");
            int BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracın ColorId'sini belirleyin: ");
            int ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracın ModelYear degerini belirleyin: ");
            string ModelYear = Console.ReadLine();
            Console.Write("Aracın DailyPrice degerini belirleyin: ");
            decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Arac Aciklamasini Yaziniz: ");
            string Description = Console.ReadLine();
            Console.Clear();
            _carDal.Add(new Car { BrandId = BrandlId, ColorId = ColorId, ModelYear = ModelYear, DailyPrice = DailyPrice, Description = Description });
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
            return _carDal.GetByBrandId(brandId);
            
           
                
               
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
