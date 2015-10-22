using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BigRoom.DataAccessLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity Find(int id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(int id);
    }
}
