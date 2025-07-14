using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface IUserService
    {
        public Task Insert(UserDTO user);
        public Task<User> GetById(int id);
        public Task Update(UserDTO userDTO);
        public Task<LoginResult> Login(string email, string password);
    }
}
