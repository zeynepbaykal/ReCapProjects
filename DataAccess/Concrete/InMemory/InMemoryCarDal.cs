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
        List<Car> _car; //globaldeğişken denir. (Naming confention)

        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car{Id = 1,BrandId=1, ColorId=1,  ModelYear = 2021, DailyPrice=730000, Description="BMW"},
                new Car{Id = 2,BrandId=2, ColorId=2,  ModelYear = 2019, DailyPrice=270000, Description="HONDA"}, 
                
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

      
        public void Delete(Car car)
        {
            Car productToDelete = _car.SingleOrDefault(p => p.Id == car.Id);

            _car.Remove(productToDelete); //direk  olarak bu kod ile silme işlemi yapamyız çünkü referansları farklı. referans tiplerini bu şekilde silemeyiz. bool , string , int vs olsaydı silebilirdik yani değer tip.
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(p => p.Id == Id).ToList();
        }

        public object GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //gönderdiğim ürün ıd sine sahip olan listedeki ürünü bul.
            Car carToUpdate= _car.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;

        }

        List<CarDetailDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
