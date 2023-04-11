using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.PlanningDataMigration.Repository.Core.Abstractions
{
    public interface IDbSettings
    {
        public DbTypesEnum DbType { get; init; }
        public string ConnectionUri { get; init; }
        public string DatabaseName { get; init; }
    }
}
