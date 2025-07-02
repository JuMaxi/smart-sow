using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class GrowthSettingsService : IGrowthSettingsService
    {
        private readonly IGrowthSettingsRepository _growthSettingsRepository;

        public GrowthSettingsService(IGrowthSettingsRepository growthSettingsDbAccess)
        {
            _growthSettingsRepository = growthSettingsDbAccess;
        }

        public async Task Insert(GrowthSettings settings)
        {
            await _growthSettingsRepository.Insert(settings);
        }

        public async Task<GrowthSettings> GetById(int id)
        {
            return await _growthSettingsRepository.GetById(id);
        }

        public async Task Update(GrowthSettings settings)
        {
            GrowthSettings toUpdate = await _growthSettingsRepository.GetById(settings.Id);

            toUpdate.TemperatureCelsius = settings.TemperatureCelsius;
            toUpdate.Humidity = settings.Humidity;
            toUpdate.DailySolarHours = settings.DailySolarHours;

            await _growthSettingsRepository.Update(toUpdate);
        }

        public async Task Delete(int id)
        {
            await _growthSettingsRepository.Delete(id);
        }
    }

}
