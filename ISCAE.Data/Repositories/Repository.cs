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
        //private log4net.ILog _logger = Log4NetHelper.GetLogger(typeof(TEntity));
        //public log4net.ILog Logger { get { return null; } }
        public DB Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new DB();
                }
                return _context;
            }
            set { _context = value; }
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
                Context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
                return null;
            }
            
        }

       public TEntity Delete(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Remove(entity);
                Context.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
                return entity;
            }
            
        }
        
        public TEntity Edit(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Attach(entity);
                var entry = Context.Entry(entity);
                entry.State = EntityState.Modified;
                Context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
                return null;
            }
            
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().Where(predicate).AsEnumerable();
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
                return null;
            }
            
        }

        public TEntity Get(int id)
        {
            try
            {
                return Context.Set<TEntity>().Find(id);
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
                return null;
            }
            
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>().AsEnumerable();
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
                return null;
            }
            
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
