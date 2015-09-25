using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public virtual TEntity Find(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #region IDisposable

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        #endregion
    }
}
