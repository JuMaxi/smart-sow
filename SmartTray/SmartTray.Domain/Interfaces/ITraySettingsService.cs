using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySettingsService
    {
        public Task Insert(TraySettings settings);
        public Task<TraySettings> GetById(int id);
        public Task Update(TraySettings settings);
        public Task Delete(int id);
    }
}
