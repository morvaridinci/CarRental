using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (MyDatabaseContext context =new MyDatabaseContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors 
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto 
                             {CarName=car.CarName,
                              BrandName=brand.BrandName, 
                              DailyPrice=car.DailyPrice,
                              ColorName=color.ColorName};
                return result.ToList();
            }
            
        }
    }
}
