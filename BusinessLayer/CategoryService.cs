using System;
using System.Collections.Generic;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer
{
    public class CategoryService : IDisposable
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Category> GetCategories()
        {
            return unitOfWork.CategoryRepository.GetAll();
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
                    unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        #endregion
    }
}
