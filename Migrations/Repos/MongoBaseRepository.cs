using Migrations.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Migrations.Repos
{
    internal abstract class MongoBaseRepository : IRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<BsonDocument> _collection;

        public MongoBaseRepository(IDbSettings dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.ConnectionURI);
            _mongoDatabase = mongoClient.GetDatabase(dbSettings.DatabaseName);
            _collection = _mongoDatabase.GetCollection<BsonDocument>(CollectionName);
        }

        public abstract string CollectionName { get; }

        public IMongoCollection<BsonDocument> Collection { 
            get {
                return _collection;
            }
        }

        public List<BsonDocument> GetAllRecords()
        {
            return FindWhere(_ => true);
        }

        public List<BsonDocument> FindWhere(Expression<Func<BsonDocument, bool>> predicate)
        {
            var filter = Builders<BsonDocument>.Filter.Where(predicate);
            return _collection.Find(filter).ToList();
        }
    }
}
