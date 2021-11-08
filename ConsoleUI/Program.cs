using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
   public class Program
    {
        
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());




            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine((car.BrandId +  car.ColorId + car.DailyPrice + car.Description));

            //}

            //ProductTest();
            CarManager carManager = new CarManager(new EfCarDal());

            var cars = carManager.GetCarDetails();

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.BrandName} --- {car.ColorName} ---- {car.DailyPrice}");
            }




        }
        private static void ProductTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "/" + car.ColorId + "/" + car.DailyPrice);
            }
        }
    }
}
