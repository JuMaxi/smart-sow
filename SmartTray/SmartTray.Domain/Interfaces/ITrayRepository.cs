using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITrayRepository
    {
        public Task Insert(Tray tray);
        public Task<Tray> GetByIdToArduino(int trayId, string token);

        public Task<Tray> GetById(int trayId, int userId);
        public Task<List<Tray>> GetAll(int userId);
        public Task Update(Tray tray);
        public Task UpdateStatus(Tray tray);
    }
}
