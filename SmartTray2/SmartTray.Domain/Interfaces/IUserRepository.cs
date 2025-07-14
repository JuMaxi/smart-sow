using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task Insert(User user);
        public Task<User> GetById(int id);
        public Task Update(User user);
        public Task Delete(int id);
        public Task<User> GetByEmail(string email);

    }
}
