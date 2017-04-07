using ISCAE.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public class CommonService<TEntity> : ICommonService<TEntity> where TEntity : class
    {
        private IRepository<TEntity> _repository;
        public CommonService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public void Add(TEntity entity)
        {
            if(entity != null)
            {
                _repository.Add(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _repository.Delete(entity);
            }
        }

        public void Edit(TEntity entity)
        {
            if (entity != null)
            {
                _repository.Edit(entity);
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public TEntity Get(int id)
        {
            if (id > 0)
            {
                return _repository.Get(id);
            }
            return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
