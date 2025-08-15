using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TraySettingsService : ITraySettingsService
    {
        private readonly ITraySettingsRepository _traySettingsRepository;

        public TraySettingsService(ITraySettingsRepository traySettingsRepository)
        {
            _traySettingsRepository = traySettingsRepository;
        }

        public async Task Insert(TraySettings settings)
        {
            if (settings != null)
            {
                await _traySettingsRepository.Insert(settings);
            }
        }

        public async Task<TraySettings> GetById(int id)
        {
            return await _traySettingsRepository.GetById(id);
        }

        public async Task Update(TraySettings settings)
        {
            if (settings != null)
            {
                TraySettings toUpdate = await _traySettingsRepository.GetById(settings.Id);

                if (toUpdate != null)
                {
                    toUpdate.TemperatureCelsius = settings.TemperatureCelsius;
                    toUpdate.Humidity = settings.Humidity;
                    toUpdate.DailySolarHours = settings.DailySolarHours;

                    await _traySettingsRepository.Update(toUpdate);
                }
            }
        }

        public async Task Delete(int id)
        {
            await _traySettingsRepository.Delete(id);
        }
    }

}
