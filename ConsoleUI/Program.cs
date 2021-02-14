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

             //BrandTest();

            // ColorTest();
            //CustomerAdd();

            GetAllRentalDetailList();
        }
        private static void GetAllRentalDetailList()
        {
            // RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //// Console.WriteLine("Kiralanan Arabalar Listesi: \nId\tCar Name\tCustomer Name\tRent Date\tReturn Date");
            // var result = rentalManager.GetRentalDetails(1);
            // if (result.Success == true)
            // {
            //     foreach (var rental in result.Data)
            //     {
            //         Console.WriteLine(rental.RentDate);
            //        // +"\t" + rental.CarName + "\t" + rental.CustomerName + "\t" + rental.RentDate + "\t" + rental.ReturnDate
            //     }
            //     Console.WriteLine(result.Message);
            // }

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.RentDate);
                }
            }
        }
        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer { CustomerId = 1, UserId = 1, CompanyName = "fgh" });
            customerManager.Add(new Customer { CustomerId = 2, UserId = 2, CompanyName = "xyz" });
            customerManager.Add(new Customer { CustomerId = 3, UserId = 3, CompanyName = "abc" });
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

            //var result = brandManager.GetAll();
            //if(result.Success == true)
            //{
            //    foreach (var brand in result.Data)
            //    {
            //        Console.WriteLine(brand.BrandName);
            //    }
            //    Console.WriteLine(result.Message);
            //}

            var result=brandManager.Add(new Brand { BrandId = 7, BrandName= "Alfa Romeo" });
            if(result.Success == true)
            {
                Console.WriteLine(result.Message);
            }

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

           /* var result = carManager.GetCarDetails();
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
            }*/

            

            /*foreach (var car in carManager.GetByColorId(3))
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + " " + car.ModelYear + " " + car.Description);
            }*/
        }
    }
}
