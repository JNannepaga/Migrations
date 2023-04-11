using MongoDB.Bson;

namespace Migrations.GroupLevelDefaults
{
    internal interface IGroupLevelDefaultsActions
    {
        void UpdateRiskProfileDetails();
        BsonDocument Build();
    }
}
