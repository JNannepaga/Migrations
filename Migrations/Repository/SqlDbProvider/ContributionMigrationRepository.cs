using System;
using Microservice.PlanningDataMigration.Entities;
using Microservice.PlanningDataMigration.Repository.Core;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;

namespace Microservice.PlanningDataMigration.Repository.SqlDbProvider
{
    public class ContributionMigrationRepository
        : SqlRepository<ContributionMigration, Guid>, IContributionMigrationRepository
    {
        public ContributionMigrationRepository(IDbSettings dbSettings, IDbContext dbContext)
            : base(dbSettings, dbContext)
        {
        }
    }
}
