using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
          List<CarDetailDto> GetCarDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null);

        
        //List<Car> GetAll();

        //void Add(Car car);

        //void Update(Car car);

        //void Delete(Car car);

        //List<Car> GetById(int Id);
    }
}
