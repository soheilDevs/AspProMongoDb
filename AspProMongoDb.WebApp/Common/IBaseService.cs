using AspProMongoDb.WebApp.DataBase;
using AspProMongoDb.WebApp.Entities;
using AspProMongoDb.WebApp.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace AspProMongoDb.WebApp.Common
{
    public interface IBaseService<TEntity> where TEntity:BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
    }

    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;
        private readonly MongoDbContext _context;
        public BaseService(MongoDbContext context)
        {
            //var client=new MongoClient(settings.ConnectionString);
            _context = context;
            var dataBase = context.GetDataBase();
            _collection = dataBase.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public void Insert(TEntity entity)
        {
            _context.StartTransaction();
            _collection.InsertOne(_context.GetSession(),entity);

        }

        public void Update(TEntity entity)
        {
            _context.StartTransaction();
            _collection.ReplaceOne(_context.GetSession(),f => f.Id == entity.Id, entity);
        }

        public void Delete(Guid id)
        {
            _context.StartTransaction();
            _collection.DeleteOne(_context.GetSession(), f => f.Id == id);
        }

        public TEntity GetById(Guid id)
        {
            return _collection.Find(f => f.Id == id).FirstOrDefault();
        }

        public List<TEntity> GetAll()
        {
            return _collection.Find(t => true).ToList();
        }
    }
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
