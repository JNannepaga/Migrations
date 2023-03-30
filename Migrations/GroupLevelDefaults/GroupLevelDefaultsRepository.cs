using Migrations.Core;
using Migrations.Repos;

namespace Migrations.GroupLevelDefaults
{
    internal class GroupLevelDefaultsRepository : MongoBaseRepository
    {
        //Todo: Move this to program.cs & make dbsettigs as singleton.
        public GroupLevelDefaultsRepository()
            : this(new DbSettings(ConnectionURI: "mongodb://localhost:27017", DatabaseName: "Malips"))
        {

        }
        public GroupLevelDefaultsRepository(IDbSettings dbSettings)
            : base(dbSettings)
        {
        }

        public override string CollectionName => "GroupLevelDefaults";
    }
}
