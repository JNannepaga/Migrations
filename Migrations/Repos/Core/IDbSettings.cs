using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations.Core
{
    internal interface IDbSettings
    {
        string ConnectionURI { get; init; }
        string DatabaseName { get; init; }
    }
}
