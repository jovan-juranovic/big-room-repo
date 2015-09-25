using System;
using BigRoom.DataAccessLayer.Repositories;
using BigRoom.Model;

namespace BigRoom.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private BigRoomContext ctx = new BigRoomContext();
        private IRepository<Category> categoryRepository;

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new Repository<Category>(ctx);
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
                    categoryRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        #endregion
    }
}
