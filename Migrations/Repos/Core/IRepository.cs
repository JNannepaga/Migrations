
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace Migrations.Core
{
    internal interface IRepository
    {
        public string CollectionName { get; }
        public IMongoCollection<BsonDocument> Collection { get; }
        List<BsonDocument> GetAllRecords();
        List<BsonDocument> FindWhere(Expression<Func<BsonDocument, bool>> predicate);
    }
}
