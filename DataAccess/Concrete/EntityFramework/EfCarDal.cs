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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on
                             c.BrandId equals b.Id
                             join cl in context.Colors on
                             c.ColorId equals cl.Id
                             select new CarDetailDto { CarId = c.Id, BrandName = b.Name, ColorName = cl.Name, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }

        //object ICarDal.GetCarDetails()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(Car entity)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var addedEntity = context.Entry(entity);
        //        addedEntity.State = EntityState.Added;
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        return context.Set<Car>().SingleOrDefault(filter);
        //    }
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        return filter == null
        //            ? context.Set<Car>().ToList()
        //            : context.Set<Car>().Where(filter).ToList();

        //    }
        //}

        //public void Update(Car entity)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}

    }
}
