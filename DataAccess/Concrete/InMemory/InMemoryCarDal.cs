using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=100, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=2, BrandId=1, ColorId=2, DailyPrice=150, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=3, BrandId=2, ColorId=1, DailyPrice=180, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=4, BrandId=3, ColorId=3, DailyPrice=105, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=5, BrandId=1, ColorId=1, DailyPrice=120, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=6, BrandId=2, ColorId=2, DailyPrice=130, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=7, BrandId=1, ColorId=3, DailyPrice=100, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=8, BrandId=2, ColorId=3, DailyPrice=145, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=9, BrandId=1, ColorId=1, DailyPrice=150, ModelYear=2002, Description="Binek araba" },
            new Car{CarId=10, BrandId=1, ColorId=3, DailyPrice=120, ModelYear=2002, Description="Binek araba" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
