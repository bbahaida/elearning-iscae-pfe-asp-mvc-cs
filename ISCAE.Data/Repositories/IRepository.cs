using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Edit(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
