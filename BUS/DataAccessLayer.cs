using DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BUS
{
    public class DataAccessLayer<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork unitOfWork;
        private bool autoSaveChange = true;
        private bool disposed = false;

        public DataAccessLayer()
        {
            unitOfWork = new UnitOfWork();
        }

        public DataAccessLayer(bool autoSaveChange)
        {
            this.autoSaveChange = autoSaveChange;

        }

        public DataAccessLayer(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            unitOfWork.Repository<TEntity>().Delete(id);
            if (this.autoSaveChange == true)
            {
                unitOfWork.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            unitOfWork.Repository<TEntity>().Delete(entity);
            if (this.autoSaveChange)
            {
                unitOfWork.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }
            else
            {
                if (disposing)
                {
                    unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return unitOfWork.Repository<TEntity>().Get(filter, orderBy, includeProperties);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return unitOfWork.Repository<TEntity>().GetAll();
        }

        public TEntity GetById(int id)
        {
            return unitOfWork.Repository<TEntity>().GetById(id);
        }

        public IPagedList<TResult> GetPagedList<TResult>(System.Linq.Expressions.Expression<Func<TEntity, TResult>> selector, System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int pageIndex = 0, int pageSize = 20) where TResult : class
        {
            return unitOfWork.Repository<TEntity>().GetPagedList(selector, filter, orderBy, includeProperties, pageIndex, pageSize);
        }

        public IEnumerable<TResult> GetProperties<TResult>(System.Linq.Expressions.Expression<Func<TEntity, TResult>> selector, System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "") where TResult : class
        {
            return unitOfWork.Repository<TEntity>().GetProperties(selector, filter, orderBy, includeProperties);
        }

        public TResult GetPropertiesById<TResult>(int id, System.Linq.Expressions.Expression<Func<TEntity, TResult>> selector, string includeProperties = "") where TResult : class
        {
            return unitOfWork.Repository<TEntity>().GetPropertiesById(id, selector, includeProperties);
        }

        public void Insert(TEntity entity)
        {
            unitOfWork.Repository<TEntity>().Insert(entity);
            if (this.autoSaveChange)
            {
                unitOfWork.SaveChanges();
            }
        }

        public TEntity SingleOrDefault(int primaryKey)
        {
            return unitOfWork.Repository<TEntity>().SingleOrDefault(primaryKey);
        }

        public void Update(TEntity entity)
        {
            unitOfWork.Repository<TEntity>().Update(entity);
            if (this.autoSaveChange)
            {
                unitOfWork.SaveChanges();
            }
        }

        PagedList.IPagedList<TResult> IRepository<TEntity>.GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, int pageIndex, int pageSize)
        {
            return unitOfWork.Repository<TEntity>().GetPagedList(selector, filter, orderBy, includeProperties, pageIndex, pageSize);
        }
    }
}
