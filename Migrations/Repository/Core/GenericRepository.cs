using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;

namespace Microservice.PlanningDataMigration.Repository.Core
{
    public abstract class GenericRepository<TEntity, TKey>
        : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly IDbContext _dbContext;
        protected readonly IDbSettings _dbSettings;

        protected GenericRepository(IDbSettings dbSettings, IDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbSettings);
            ArgumentNullException.ThrowIfNull(dbContext);

            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }


        public abstract IEnumerable<TEntity> Entities();
        public abstract TEntity GetById(TKey id);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract TEntity FindOne(Expression<Func<TEntity, bool>> predicate);
        public abstract IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        public abstract void Add(TEntity entity);

        public abstract void Dispose();
    }
}
