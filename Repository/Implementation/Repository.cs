using DomainModels.Context;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BMSEntities2 _context=null;
        private DbSet<TEntity> dbSet=null ;
        public Repository()
        {
            _context =new BMSEntities2();
            dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int Id)
        {
            TEntity model = dbSet.Find(Id);
            dbSet.Remove(model);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
