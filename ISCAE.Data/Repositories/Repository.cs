using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class Repository<DB,TEntity> : IRepository<TEntity> where TEntity : class where DB : DbContext,new()
    {
        private DB _context;

        public DB Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsEnumerable();
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
