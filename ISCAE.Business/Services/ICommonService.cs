using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace ISCAE.Business.Services
{
    public interface ICommonService<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Edit(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
