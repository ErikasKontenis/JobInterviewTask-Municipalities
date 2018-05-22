using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Municipalities.Contracts.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Get(object id);

        TEntity Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "");

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        List<TEntity> List(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        TEntity Insert(TEntity entity, bool autosave = true);

        TEntity Save(TEntity entity);

        void Update(TEntity entity, bool autosave = true);

        void Delete(TEntity entity, bool autosave = true);

        int SaveChanges();
    }
}
