using System;
using System.Collections.Generic;
using System.Linq;
using BigRoom.Model;

namespace BigRoom.DataAccessLayer.Repositories
{
    public class CategoryRepository : IDisposable
    {
        private BigRoomContext ctx;

        public CategoryRepository(BigRoomContext ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Category> GetAll()
        {
            return ctx.Categories.ToList();
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
