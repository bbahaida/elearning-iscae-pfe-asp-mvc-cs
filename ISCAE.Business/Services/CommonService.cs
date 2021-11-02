using ISCAE.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace ISCAE.Business.Services
{
    public class CommonService<TEntity> : ICommonService<TEntity> where TEntity : class
    {
        private IRepository<TEntity> _repository;
        //log4net.ILog logger = Log4NetHelper.GetLogger(typeof(TEntity));
        public CommonService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes("iscae" + input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        public TEntity Add(TEntity entity)
        {
            if (entity != null)
            {
                entity = _repository.Add(entity);
                if (entity != null)
                {
                    return entity;
                }
            }
            return null;
        }
        

        public TEntity Delete(TEntity entity)
        {
            if (entity != null)
            {
                entity = _repository.Delete(entity);
                if (entity == null)
                {
                    //logger.Info("Delete from database");
                    return null;
                }
            }
            return entity;
        }

        public TEntity Edit(TEntity entity)
        {
            if (entity != null)
            {
                entity = _repository.Edit(entity);
                if (entity != null)
                {
                    return entity;
                }
            }
            return null;
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
    }
}
