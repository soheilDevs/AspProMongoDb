using AspProMongoDb.WebApp.Entities;
using AspProMongoDb.WebApp.Models;
using MongoDB.Driver;

namespace AspProMongoDb.WebApp.Services
{
    public class UserService:IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(MongoSettings  settings,IMongoClient client)
        {
            //var client=new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);
            _users = dataBase.GetCollection<User>("Users");
        }
        public void Insert(User user)
        {
            _users.InsertOne(user);
        }

        public void Update(User user)
        {
            _users.ReplaceOne(f => f.Id == user.Id, user);
        }

        public void Delete(Guid userId)
        {
            _users.DeleteOne(f => f.Id == userId);

        }

        public User GetById(Guid userId)
        {
            return _users.Find(f => f.Id == userId).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _users.Find(_ => true).ToList();
        }
    }
}
