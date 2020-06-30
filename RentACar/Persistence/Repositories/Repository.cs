using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RentACar.DAO
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public TEntity Get(int id)
        {
           return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
           return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Add(TEntity entity)
        {
             _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            _context.Set<TEntity>().Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            TEntity entityToDelete = _context.Set<TEntity>().Find(id);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
        }
    }
}
