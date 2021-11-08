using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorSevice
    {
        List<Color> GetAll();
        Color GetById(int id);
        void Add(Color car);
        void Delete(Color car);
        void Update(Color car);
    }
}
