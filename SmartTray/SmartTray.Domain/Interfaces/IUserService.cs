using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface IUserService
    {
        public Task Insert(User user);
        public Task<User> GetById(int id);
        public Task Update(User user);
    }
}
