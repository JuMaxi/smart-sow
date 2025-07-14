using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TraySettingsService : ITraySettingsService
    {
        private readonly ITraySettingsRepository _growthSettingsRepository;

        public TraySettingsService(ITraySettingsRepository growthSettingsDbAccess)
        {
            _growthSettingsRepository = growthSettingsDbAccess;
        }

        public async Task Insert(TraySettings settings)
        {
            await _growthSettingsRepository.Insert(settings);
        }

        public async Task<TraySettings> GetById(int id)
        {
            return await _growthSettingsRepository.GetById(id);
        }

        public async Task Update(TraySettings settings)
        {
            TraySettings toUpdate = await _growthSettingsRepository.GetById(settings.Id);

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
