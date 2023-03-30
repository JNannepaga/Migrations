
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace Migrations.Core
{
    internal interface IRepository
    {
        List<BsonDocument> GetAllRecords();
        List<BsonDocument> FindWhen(Expression<Func<BsonDocument, bool>> predicate);
    }
}
