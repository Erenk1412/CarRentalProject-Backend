using Business.Concrete;
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

            CarMenager carMenager = new CarMenager(new InMemoryCarDal() );

              carMenager.Add(new Car());

             foreach (var car in carMenager.GetAll())
             {
                  Console.WriteLine("Id="+car.Id+" "+"MarkaId="+car.BrandId+" "+"RenkId="+car.ColorId+" "+"Fiyat"+car.DailyPrice+" "+"Model Yılı="+car.ModelYear+" "+ "Açıklama="+car.Description);
             }


             Console.WriteLine("Listeden Silmek İstediğiniz Aracın Numarasını Giriniz:");
              int id = Convert.ToInt32(Console.ReadLine());

              carMenager.Delete(new Car { Id = id });

            foreach (var b in carMenager.GetByBrandId(2))
            {
                Console.WriteLine("Id=" + b.Id + " " + "MarkaId=" + b.BrandId + " " + "RenkId=" + b.ColorId + " " + "Fiyat" + b.DailyPrice + " " + "Model Yılı=" + b.ModelYear + " " + "Açıklama=" + b.Description);

            }
            
            carMenager.Update(new Car { Id=2,BrandId=4,ColorId=2,DailyPrice=200000,ModelYear="2016",Description= "Güç (b.g.)=300"}) ;


        }
    }
}
