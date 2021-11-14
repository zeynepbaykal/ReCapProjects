using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
    public class EfRentDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
       

        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Users
                             join b in context.Customers on
                             c.UserId equals b.UserId

                             select new RentalDetailDto { CustomerId = c.UserId,CarId=b.UserId };
                return result.ToList();
            }
        }
    }
}
