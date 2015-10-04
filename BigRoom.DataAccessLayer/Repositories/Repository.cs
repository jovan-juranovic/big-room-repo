using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BigRoom.DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>  where TEntity : class
    {
        protected BigRoomContext ctx;
        protected DbSet<TEntity> dbSet; 

        public Repository(BigRoomContext ctx)
        {
            this.ctx = ctx;
            this.dbSet = ctx.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public virtual TEntity Find(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
