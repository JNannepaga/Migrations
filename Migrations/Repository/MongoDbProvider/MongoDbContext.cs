using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.PlanningDataMigration.Repository.Core.Abstractions;
using MongoDB.Driver;

namespace Microservice.PlanningDataMigration.Repository.MongoDbProvider
{
    public sealed class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly List<Action> _commands;
        private readonly IClientSessionHandle _session;

        public MongoDbContext(IDbSettings dbSettings)
        {

            //ArgumentNullException.ThrowIfNull(dbSettings);

            IMongoClient mongoClient = new MongoClient(dbSettings.ConnectionUri);
            _session = mongoClient.StartSession();
            _database = mongoClient.GetDatabase(dbSettings.DatabaseName);
            _commands = new List<Action>();
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name = "")
        {
            return _database.GetCollection<TEntity>(string.IsNullOrEmpty(name) ? typeof(TEntity).Name : name);
        }

        public void Add<TEntity>(TEntity entity)
        {
            _commands.Add(() => GetCollection<TEntity>().InsertOne(entity));
        }

        public void SaveChanges()
        {
            _session.StartTransaction();

            _commands.ForEach(cmd =>
            {
                cmd.Invoke();
            });

            _session.CommitTransaction();

            _commands.Clear();
        }

        public void DiscardChanges()
        {
            _commands.Clear();
            _session.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            _session.StartTransaction();

            _commands.ForEach(cmd =>
            {
                cmd.Invoke();
            });

            await _session.CommitTransactionAsync();

            _commands.Clear();
        }

        public Task DiscardChangesAsync()
        {
            _commands.Clear();
            _session.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose() => _session.Dispose();
    }
}

