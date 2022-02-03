using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        //private InMemoryCarDal inMemoryCarDal;

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("car.add, admin")] //yetki
        [ValidationAspect(typeof(CarValidator))] //35.satırdakı kodun yerine yazdık 
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //business code--iş gereksinimlerini yazdığımız koddur.
            //validation--iş kurallarına dahil etmek için yapılan doğrulaama kodudur.

           
            //ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded); // constructor olusturduk

        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 100)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }

        [CacheAspect] //key,value
        public IDataResult <List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 12)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        //public IDataResult<List<CarDetailDto>> GetCarDetailId(int id)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == id), Messages.CarDetailsReceived);
        //}

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(filter), "Ürünler Listelendi.");
        }
        public IDataResult<List<CarDetailDto>>GetCarDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }
       

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        
    }
}
