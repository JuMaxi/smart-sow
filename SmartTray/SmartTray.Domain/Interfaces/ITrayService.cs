using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITrayService
    {
        public Task Insert(Tray tray, TraySettings settings, int userId);
        public Task<Tray> GetById(int id, int userId);
        public Task<List<Tray>> GetAll(int userId);
    }
}
