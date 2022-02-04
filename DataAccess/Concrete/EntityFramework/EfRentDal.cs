using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
       

        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rental in context.Rentals
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join car in context.Cars on rental.CarId equals car.Id
                             join user in context.Users on customer.UserId equals user.Id
                             select new RentalDetailDto { CarName = car.CarName, UserName = user.FirstName + " " + user.LastName, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate };
                return result.ToList();
            }
        }

        //public override void Add(Rental entity)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        entity.RentDate = DateTime.Now;
        //        var AddedEntity = context.Entry(entity);
        //        AddedEntity.State = EntityState.Added;
        //        context.SaveChanges();
        //    }
        //}
    }
}
