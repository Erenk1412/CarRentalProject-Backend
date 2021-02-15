using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorTest();
            AddCar();
            DtoTest();
            ColorTest();
            ColorGetTest();

        }

        private static void ColorGetTest()
        {
            ColorMenager colorMenager = new ColorMenager(new EfColorDal());
            foreach (var color in colorMenager.GetById(2).Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void DtoTest()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
        
                foreach (var car in carMenager.GetCarDetails().Data)
                {
                    Console.WriteLine("Brand Name=" + car.BrandName + " " + "Color Name=" + car.ColorName + " " + "Price=" + car.DailyPrice+"\n");
                }
         
           
        }

        private static void AddCar()
        {
            CarMenager carMenager = new CarMenager(new EfCarDal());
            carMenager.Add(new Car { BrandId = 3, ColorId = 4, ModelYear = "2016", DailyPrice = 150000, Description = "Dizel" });
            foreach (var item in carMenager.GetAll().Data)
            {
                Console.WriteLine(item.ModelYear);
            }
        }

        private static void ColorTest()
        {
            ColorMenager colorMenager = new ColorMenager(new EfColorDal());
            foreach (var color in colorMenager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }
    }
}
