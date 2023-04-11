using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.PlanningDataMigration.Repository.Core.Abstractions
{
    public interface IDbContext : IDisposable
    {
        void SaveChanges();
        void DiscardChanges();
        Task SaveChangesAsync();
        Task DiscardChangesAsync();
    }
}
