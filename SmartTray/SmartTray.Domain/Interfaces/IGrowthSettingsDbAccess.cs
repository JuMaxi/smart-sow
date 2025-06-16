using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface IGrowthSettingsDbAccess
    {
        public Task Insert(GrowthSettings settings);
    }
}
