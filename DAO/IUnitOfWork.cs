using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        ApplicationDbContext Context();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
