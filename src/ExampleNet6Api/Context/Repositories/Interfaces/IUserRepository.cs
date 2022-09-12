using Context.Models;

namespace Context.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
    }
}