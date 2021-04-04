using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SqlCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (SqlCarContext context = new SqlCarContext())
            {

                var result = from car in filter== null ? context.Cars : context.Cars.Where(filter)
                             join rental in context.Rentals
                             on car.Id equals rental.CarId

                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 CarName = car.CarName,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();



            }
        }
    }
}
