using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{

    //generic constraint=generic kısıt demektir
    //class: referans tip olabilir demektir.
    //IEntity :IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(); new'lenebilir olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filter=null filtre vermeyedebilirsin demektir. eğer filtre vermezsek tüm datayı çekmış oluruz. Eğer filtre verirse datayı filtreye göre verir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        /* List<T> GetAllByCategory(int categoryId);*///ürünleri kategoriye göre listele //Expression kodu sayesinde yani LINQ sayesinde bu koda gerek kalmadı.
    }
}