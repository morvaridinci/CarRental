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
            // CarTest();

            // BrandTest();

            // ColorTest();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            /* foreach (var brand in brandManager.GetAll())
             {
                 Console.WriteLine(brand.BrandName);
             }*/

            customerManager.Add(new Customer { Id = 1, UserId = 1,CompanyName="fgh"});
            customerManager.Add(new Customer { Id = 2, UserId = 2, CompanyName = "xyz" });
            customerManager.Add(new Customer { Id = 3, UserId = 3, CompanyName = "abc" });


        }

        private static void ColorTest()
        {
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            /* foreach (var brand in brandManager.GetAll())
             {
                 Console.WriteLine(brand.BrandName);
             }*/

            brandManager.Add(new Brand {BrandId=4 , BrandName="Nissan"});
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            /* Console.WriteLine("CarId \t BrandId \t ColorId \t DailyPrice \t ModelYear \t Description");
             Console.WriteLine("----------------------------------------------------------------------");
             foreach (var car in carManager.GetAll())
             {
                 Console.WriteLine(car.CarId + "\t" + car.BrandId + "\t" + car.ColorId + "\t" + car.DailyPrice + "\t  " + car.ModelYear + "\t" + car.Description);
             }*/

            var result = carManager.GetCarDetails();
            if(result.Success == true)
            {
                foreach (var car in result.Data )
                {
                    Console.WriteLine(car.CarName + "  " + car.BrandName + "  " + car.ColorName + "  " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            

            /*foreach (var car in carManager.GetByColorId(3))
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + " " + car.ModelYear + " " + car.Description);
            }*/
        }
    }
}
