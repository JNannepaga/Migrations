
using MongoDB.Bson;
using MongoDB.Driver;

namespace Migrations.GroupLevelDefaults
{
    internal class Tranformer
    {
        public static void Run()
        {
            var repo = new GroupLevelDefaultsRepository();
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Empty;
            var tenentId = "94345625-6ee8-4efe-af22-362505c92902";
            filter &= filterBuilder.Eq("tenentId", tenentId);
            var gldCollection = repo.Collection.Find(filter).ToList();

            foreach (var gldDocument in gldCollection)
            {
                var actions = new GroupLevelDefaultsActions(gldDocument);
                actions.UpdateRiskProfileDetails();
                Console.WriteLine(actions.Build().ToJson());
                SaveGLD(repo, actions.Build(), tenentId);

                static void SaveGLD(GroupLevelDefaultsRepository repo, BsonDocument updatedDoc, string tenentId)
                {
                    var filterBuilder = Builders<BsonDocument>.Filter;
                    var filter = filterBuilder.Empty;
                    filter &= filterBuilder.Eq("tenentId", tenentId);
                    var updateOptions = new UpdateOptions { IsUpsert = false };

                    repo.Collection.ReplaceOne(filter, updatedDoc);

                    return;
                }
            }
        }
    }
}

//STAGE1
/*
 
 step1: Fetch the TenantId = 1 + GroupId = G1 record.
-------------Level 1-----------
 step2: store it in record (groupId, parentId, isRootNode = true);
-------------Level 2-----------
 step3: GldCollection.Where(parentGroupId = 123)  --> All children (GC1, GC2, GC3)
 step4: store it in record (groupId, parentId, isRootNode = false);
 step5: parentGroupId = GC1
 Repeat Step3 to Step5 recursively until a tree is formed.
 
 */

//STAGE2
/*
-------------Level 1-----------
 step1: parentGroupId = G1
 step2: load Doc from DB using  TenantId + GroupId
 step3: GetRiskProfiles => change Id = NewId -> save to Record
 step4: Dispose Doc
-------------Level 2-----------
 step5: parentGroupId = GC1 
 step6: load Doc from DB using  TenantId + GroupId
 step7: UseParent ? return(donot touch the Doc) : GetRiskProfiles => change Id = NewId -> save to Record
 step8: Dispose Doc

 */