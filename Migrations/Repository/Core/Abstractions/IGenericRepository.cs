using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microservice.PlanningDataMigration.Repository.Core.Abstractions
{
    public interface IGenericRepository<TEntity, TKey>
        : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Entities();

        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
    }
}
