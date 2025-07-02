using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITrayRepository
    {
        public Task Insert(Tray tray);
        public Task<Tray> GetById(int id, int userId);
        public Task<List<Tray>> GetAll(int userId);
    }
}
