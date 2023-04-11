using System;
using System.Threading.Tasks;
using Microservice.PlanningDataMigration.Entities;
using Microservice.PlanningDataMigration.Repository.Core;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;
using Microservice.PlanningDataMigration.Repository.SqlDbProvider;

namespace Microservice.PlanningDataMigration.Repos
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private readonly IDbSettings _dbSettings;

        public UnitOfWork(IDbSettings dbSettings, IDbContext dbContext)
        {
            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }

        public IContributionMigrationRepository ContributionMigrationRepository { get; }

        public void DiscardChanges() => _dbContext.DiscardChanges();
        public Task DiscardChangesAsync() => _dbContext.DiscardChangesAsync();
        public void Dispose() => _dbContext.Dispose();
        public void SaveChanges() => _dbContext.SaveChanges();
        public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}
