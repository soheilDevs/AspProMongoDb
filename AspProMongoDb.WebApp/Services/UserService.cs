using AspProMongoDb.WebApp.Common;
using AspProMongoDb.WebApp.DataBase;
using AspProMongoDb.WebApp.Entities;
using AspProMongoDb.WebApp.Models;
using MongoDB.Driver;

namespace AspProMongoDb.WebApp.Services
{
    public class UserService:BaseService<User>,IUserService
    {
        public UserService(MongoDbContext context) : base(context)
        {
        }
    }
}
