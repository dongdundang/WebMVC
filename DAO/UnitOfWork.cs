using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        private bool disposed = false;

        public UnitOfWork()
        {
            context = new ApplicationDbContext();
            context.Database.CommandTimeout = 180;
        }

        public ApplicationDbContext Context()
        {
            return this.context;
        }

        protected void Dispose(bool disposing)
        {
            if(this.disposed == true)
            {
                return;
            }
            else if (disposing)
            {
                context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new EFRepository<TEntity>(context);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
