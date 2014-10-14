using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Core.Data
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        TEntity FindById(TKey id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);
        void Delete(TEntity entity);
        int Count();
        IQueryable<TEntity> Query();
    }
}
