using example_net6_api.Context.Models;
using example_net6_api.Context.Repositories.Interfaces;

namespace example_net6_api.Context.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ApiContext _db;

        public UserRepository(ApiContext db)
        {
            _db = db;
        }

        public List<User> GetUsers()
        {
            var users = _db.Users.ToList();
            return users;
        }
    }
}