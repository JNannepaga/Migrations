using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations.GroupLevelDefaults
{
    internal interface IGroupLevelDefaultsActions
    {
        BsonDocument GetRiskProfile(Guid riskProfileId);
        BsonDocument updateFieldName(string fieldName, string updatedValue);
    }
}
