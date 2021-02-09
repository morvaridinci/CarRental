using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("CarId \t BrandId \t ColorId \t DailyPrice \t ModelYear \t Description");
            Console.WriteLine("----------------------------------------------------------------------");
             foreach (var car in carManager.GetAll())
              {
                  Console.WriteLine(car.CarId+"\t"+ car.BrandId + "\t" + car.ColorId + "\t" + car.DailyPrice + "\t  " + car.ModelYear + "\t" + car.Description);
              }


            /* foreach (var car in carManager.GetByBrandId(3))
             {
                 Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + " " + car.ModelYear + " " + car.Description);
             }*/

            /*foreach (var car in carManager.GetByColorId(3))
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + " " + car.ModelYear + " " + car.Description);
            }*/
            
        }
    }
}
