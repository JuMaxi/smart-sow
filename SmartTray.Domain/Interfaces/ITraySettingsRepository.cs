using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySettingsRepository
    {
        public Task Insert(TraySettings settings);
        public Task<TraySettings> GetById(int trayId);
        public Task Update(TraySettings settings);
        public Task Delete(int id);
    }
}
