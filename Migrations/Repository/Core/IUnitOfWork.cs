using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.PlanningDataMigration.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IContributionMigrationRepository ContributionMigrationRepository { get; }

        void SaveChanges();
        void DiscardChanges();
        Task SaveChangesAsync();
        Task DiscardChangesAsync();
    }
}
