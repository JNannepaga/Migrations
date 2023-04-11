
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microservice.PlanningDataMigration.Repository.Core;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Microservice.PlanningDataMigration.Repository.SqlDbProvider
{
    public class SqlRepository<TEntity, TKey>
        : GenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public SqlRepository(IDbSettings dbSettings, IDbContext dbContext)
            : base(dbSettings, dbContext)
        {
            _dbSet = (dbContext as SqlDbContext).Set<TEntity>();
        }

        public override void Add(TEntity entity) => _dbSet.Add(entity);
        public override IQueryable<TEntity> Entities() => _dbSet;
        public override IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate);
        public override TEntity FindOne(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate).FirstOrDefault();
        public override IEnumerable<TEntity> GetAll() => _dbSet.AsEnumerable();
        public override TEntity GetById(TKey id) => _dbSet.Find(id);
        public override void Dispose() => throw new NotImplementedException();
    }
}
