using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface IGrowthSettingsService
    {
        public Task Insert(GrowthSettings settings);
        public Task<GrowthSettings> GetById(int id);
        public Task Update(GrowthSettings settings);
    }
}
