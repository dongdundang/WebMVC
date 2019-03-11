using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAO
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();
        ICollection<TResult> GetProperty<TResult>(Expression<Func<TEntity, TResult>> selector) where TResult : class;
        TEntity GetById(long id);
        void AddOrUpdate(TEntity item);
        void Delete(long id);
        void Edit(TEntity item);
    }
}
