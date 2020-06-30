using System;
using System.Collections.Generic;

namespace RentACar.DAO
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> GetAll();

        void Add(TEntity entity);

        void Remove(int id);

        void Update(TEntity entityToUpdate);

        bool SaveChanges();
    }
}
