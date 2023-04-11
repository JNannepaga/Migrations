using MongoDB.Bson;

namespace Migrations.GroupLevelDefaults
{
    internal record GLDRecord
    {
        public bool isRootNode { get; set; }
        public KeyValuePair<Guid,Guid> GroupIdMapper { get; set; }
        public KeyValuePair<Guid, Guid> ParentGroupIdMapper { get; set; }
        public BsonDocument GLD_Document { get; set; } = new(); //Place doc only while processing
        public List<GLDRecord> ChildNodes { get; set; } = new();
    }
}
