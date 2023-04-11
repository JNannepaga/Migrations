
using Microservice.PlanningDataMigration.Repository.Core;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;

namespace Microservice.PlanningDataMigration.Repository.MongoDbProvider
{
    public record DbSettings(DbTypesEnum DbType = DbTypesEnum.MONGO, string ConnectionUri = "mongodb://localhost:27017", string DatabaseName="Malips") : IDbSettings;

}
