using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class GrowthSettingsService : IGrowthSettingsService
    {
        private readonly IGrowthSettingsDbAccess _growthSettingsDbAccess;

        public GrowthSettingsService(IGrowthSettingsDbAccess growthSettingsDbAccess)
        {
            _growthSettingsDbAccess = growthSettingsDbAccess;
        }

        public async Task Insert(GrowthSettings settings)
        {
            await _growthSettingsDbAccess.Insert(settings);
        }
    }

}
