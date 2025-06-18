using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITrayDbAccess
    {
        public Task Insert(Tray tray);
        public Task<Tray> GetById(int id);
        public Task<List<Tray>> GetAll();
    }
}
