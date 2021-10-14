using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IRepository<TEntity> where TEntity :class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int Id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int Id);

        void Save();

    }
}
