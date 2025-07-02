using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface IGrowthSettingsRepository
    {
        public Task Insert(GrowthSettings settings);
        public Task<GrowthSettings> GetById(int trayId);
        public Task Update(GrowthSettings settings);
        public Task Delete(int id);
    }
}
