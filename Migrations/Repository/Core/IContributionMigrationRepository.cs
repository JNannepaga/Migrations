using System;
using Microservice.PlanningDataMigration.Entities;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;

namespace Microservice.PlanningDataMigration.Repository.Core
{
    public interface IContributionMigrationRepository
        : IGenericRepository<ContributionMigration, Guid>
    {
    }
}
