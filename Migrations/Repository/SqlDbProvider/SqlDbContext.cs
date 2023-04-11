using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.PlanningDataMigration.Entities;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Microservice.PlanningDataMigration.Repository.SqlDbProvider
{
    public sealed class SqlDbContext : DbContext, IDbContext
    {
        public SqlDbContext(IDbSettings dbSettings, DbContextOptions<SqlDbContext> options)
            : base(options)
        {

        }


        public DbSet<ContributionMigration> ContributionMigrations { get; set; }

        public void DiscardChanges() => base.Dispose();
        public Task DiscardChangesAsync()
        {
            base.Dispose();
            return Task.CompletedTask;
        }
        public Task SaveChangesAsync() => base.SaveChangesAsync();
        void IDbContext.SaveChanges() => base.SaveChanges();
    }
}
