using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface IGrowthSettingsService
    {
        public Task Insert(GrowthSettings settings);
    }
}
