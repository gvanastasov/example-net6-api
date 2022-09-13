using example_net6_api.Context.Models;

namespace example_net6_api.Context.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
    }
}