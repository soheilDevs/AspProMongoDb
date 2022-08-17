using AspProMongoDb.WebApp.Entities;

namespace AspProMongoDb.WebApp.Services
{
    public interface IUserService
    {
        void Insert(User user);
        void Update(User user);
        void Delete(Guid userId);
        User GetById(Guid userId);
        List<User> GetUsers();
    }
}
