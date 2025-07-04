using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITrayService
    {
        public Task Insert(Tray tray, int userId);
        public Task<Tray> GetById(int id, int userId);
        public Task<List<Tray>> GetAll(int userId);
        public Task Update(Tray tray, int userId);
        public Task Deactivate(int trayId, int userId);
    }
}
