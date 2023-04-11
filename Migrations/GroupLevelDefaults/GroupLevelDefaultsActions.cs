using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Migrations.GroupLevelDefaults
{
    internal class GroupLevelDefaultsActions : IGroupLevelDefaultsActions
    {
        private readonly BsonDocument _document;

        public GroupLevelDefaultsActions(BsonDocument groupLevelDefaultsDoc)
        {
            _document = groupLevelDefaultsDoc;
        }

        public void UpdateRiskProfileDetails()
        {
            BsonArray riskProfiles = _document["riskProfiles"].AsBsonArray;
            
            foreach (var riskProfile in riskProfiles)
            {
                Guid newRiskProfile = Guid.NewGuid();
                Console.WriteLine($"Risk Profile Id {riskProfile["id"]} will be changed to {newRiskProfile}");
                riskProfile["id"] = newRiskProfile.ToString();
                UpdateRiskProfileCrmStatus(riskProfile);
            }

            void UpdateRiskProfileCrmStatus(BsonValue riskProfile)
            {
                BsonValue crm = riskProfile["crmStatus"];
                var newStatus = "locked";

                Console.WriteLine($"crm {crm["status"]} will be changed to {newStatus}");
                crm["status"] = newStatus;
            }
        }

        public BsonDocument Build()
        {
            return _document;
        }

        public class RiskProfile
        {
            public Guid Id { get; set; }
        }
    }
}
