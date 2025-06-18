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

        public async Task<GrowthSettings> GetById(int id)
        {
            return await _growthSettingsDbAccess.GetById(id);
        }

        public async Task Update(GrowthSettings settings)
        {
            GrowthSettings toUpdate = await _growthSettingsDbAccess.GetById(settings.Id);

            toUpdate.TemperatureCelsius = settings.TemperatureCelsius;
            toUpdate.Humidity = settings.Humidity;
            toUpdate.DailySolarHours = settings.DailySolarHours;

            await _growthSettingsDbAccess.Update(toUpdate);
        }

        public async Task Delete(int id)
        {
            await _growthSettingsDbAccess.Delete(id);
        }
    }

}
