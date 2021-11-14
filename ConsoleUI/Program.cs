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
            //NewMethod();

            //ProductTest();
            //CarManager carManager = new CarManager(new EfCarDal());

            //var cars = carManager.GetCarDetails();

            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"{car.BrandName} --- {car.ColorName} ---- {car.DailyPrice}");
            //}(

            //ProductTest1();

            RentalManager carManager = new RentalManager(new EfRentDal());
            

            var result = carManager.GetRentalDetails();
            if (result.Count != 0)
            {
                foreach (var car in result)
                {
                    Console.WriteLine(car.RentId + "/" + car.ReturnDate + "/" + car.RentDate + "/" + car.CustomerId);
                }
            }
            else
            {
                Console.WriteLine(result);
            }


        }
        private static void ProductTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Succes==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ColorName + "/" + car.BrandName + "/" + car.DailyPrice);
                }
            }
        }



        //private static void NewMethod()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());




        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine((car.BrandId + car.ColorId + car.DailyPrice + car.Description));

        //    }
        //}


        //private static void ProductTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());


        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.Description + "/" + car.ColorId + "/" + car.DailyPrice);
        //    }
        //}
    }
}
