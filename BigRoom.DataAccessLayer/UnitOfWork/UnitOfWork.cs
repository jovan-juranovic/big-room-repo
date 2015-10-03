using System;
using BigRoom.DataAccessLayer.Repositories;
using BigRoom.Model;

namespace BigRoom.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private BigRoomContext ctx = new BigRoomContext();
        private IRepository<Category> categoryRepository;
        private IRepository<Product> productRepository;
        private IRepository<ProductReview> reviewRepository; 

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

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new Repository<Product>(ctx);
                }

                return productRepository;
            }
        }

        public IRepository<ProductReview> ReviewRepository
        {
            get
            {
                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new Repository<ProductReview>(ctx);
                }

                return reviewRepository;
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
