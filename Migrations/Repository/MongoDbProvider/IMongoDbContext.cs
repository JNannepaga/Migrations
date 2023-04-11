using Microservice.PlanningDataMigration.Repository.Core.Abstractions;
using MongoDB.Driver;

namespace Microservice.PlanningDataMigration.Repository.MongoDbProvider
{
    public interface IMongoDbContext : IDbContext
    {
        public IMongoCollection<TEntity> GetCollection<TEntity>(string name = "");
    }
}
