using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             from ca in context.Cars
                             join r in context.Rentals
                             on ca.CarId equals r.CarId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarName =ca.CarName,
                                 CustomerName = c.CompanyName,
                                 CarId = ca.CarId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();

               

            }
        }

        public bool IsAvailable(int id)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = context.Rentals.Any(r => r.Id == id && r.ReturnDate == null);
                return result;
            }
        }
    }
}
