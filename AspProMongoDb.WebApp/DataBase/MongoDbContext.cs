using AspProMongoDb.WebApp.Models;
using MongoDB.Driver;

namespace AspProMongoDb.WebApp.DataBase
{
    public class MongoDbContext
    {
        private readonly IClientSessionHandle _session;
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _client;

        public MongoDbContext(MongoSettings settings, IMongoClient client)
        {
            _client = client;
            _session = _client.StartSession();
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoDatabase GetDataBase()
        {
            return _database;
        }

        public IClientSessionHandle GetSession()
        {
            return _session;
        }
        public void StartTransaction()
        {
            _session.StartTransaction();
        }

        public void Commit()
        {
            _session.CommitTransaction();
        }
    }
}
