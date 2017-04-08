using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace ISCAE.Data.Repositories
{
    public class Repository<DB,TEntity> : IRepository<TEntity> where TEntity : class where DB : DbContext,new()
    {
        private DB _context;
        private log4net.ILog _logger = Log4NetHelper.GetLogger(typeof(TEntity));
        public log4net.ILog Logger { get { return _logger; } }
        public DB Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }

       public TEntity Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return entity;
            }
            
        }

        public TEntity Edit(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _context.Set<TEntity>().Where(predicate).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }

        public TEntity Get(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>().AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }

    }
}
