using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAO
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(int id);
        void Delete(TEntity entity);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IEnumerable<TResult> GetProperties<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "") where TResult : class;

        IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int pageIndex = 0,
            int pageSize = 20) where TResult : class;

        TEntity GetById(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        TEntity SingleOrDefault(int primaryKey);

        TResult GetPropertiesById<TResult>(int id, Expression<Func<TEntity, TResult>> selector,
            string includeProperties = "") where TResult : class;

        IEnumerable<TEntity> GetAll();
    }
}
