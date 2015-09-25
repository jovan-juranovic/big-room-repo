using System;
using BigRoom.DataAccessLayer.Repositories;

namespace BigRoom.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private BigRoomContext ctx = new BigRoomContext();
        private CategoryRepository categoryRepository;

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(ctx);
                }

                return categoryRepository;
            }
        }

        public void Save()
        {
            ctx.SaveChanges();
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
