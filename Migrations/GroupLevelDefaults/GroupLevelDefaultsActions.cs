using MongoDB.Bson;
using System.Linq.Expressions;

namespace Migrations.GroupLevelDefaults
{
    internal class GroupLevelDefaultsActions : IGroupLevelDefaultsActions
    {
        private Expression<Func<BsonDocument, bool>> filter;

        public void GetRiskProfile(Guid riskProfileId)
        {
            filter = _ => true;
        }

        public BsonDocument updateFieldName(string fieldName, string updatedValue)
        {
            return filter.Add();
        }

        public Expression<Func<BsonDocument, bool>> predicate
    }
}
