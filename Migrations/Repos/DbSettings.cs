using Migrations.Core;

namespace Migrations.Repos
{
    internal record DbSettings(string ConnectionURI, string DatabaseName) : IDbSettings;
}
