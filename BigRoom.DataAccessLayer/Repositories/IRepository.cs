using System;
using System.Collections.Generic;

namespace BigRoom.DataAccessLayer.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
    }
}
