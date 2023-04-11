using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microservice.PlanningDataMigration.Repository.Core;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;
using MongoDB.Driver;

namespace Microservice.PlanningDataMigration.Repository.MongoDbProvider
{
    public class MongoRepository<TEntity, TKey>
        : GenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly MongoDbContext _dbContext;
        private readonly IMongoCollection<TEntity> _dbSet;

        public MongoRepository(IDbSettings dbSettings, IDbContext dbContext)
            : base(dbSettings, dbContext)
        {
            _dbContext = dbContext as MongoDbContext;
            _dbSet = _dbContext.GetCollection<TEntity>();
        }

        public override void Add(TEntity entity) => _dbContext.Add(entity);
        public override IEnumerable<TEntity> Entities() => _dbSet as IEnumerable<TEntity>;
        public override IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            var filter = Builders<TEntity>.Filter.Where(predicate);
            return _dbSet.Find(filter).ToList();
        }

        public override TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
        {
            var filter = Builders<TEntity>.Filter.Where(predicate);
            return _dbSet.Find(filter).FirstOrDefault();
        }

        public override IEnumerable<TEntity> GetAll() => _dbSet as IEnumerable<TEntity>;

        public override TEntity GetById(TKey id)
        {
            return _dbSet.Find(FilterById(id)).SingleOrDefault();

            static FilterDefinition<TEntity> FilterById(TKey id) =>
               Builders<TEntity>.Filter.Eq("Id", id);
        }

        public override void Dispose() => throw new NotImplementedException();
    }
}
