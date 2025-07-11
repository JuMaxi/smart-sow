using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class TraySettingsMapper : ITraySettingsMapper
    {
        public TraySettings ConvertToTraySettings(TraySettingsRequest request)
        {
            TraySettings settings = new()
            {
                RegisterDate = DateTime.Now,
                TemperatureCelsius = request.Temperature,
                Humidity = (HumidityLevel)request.Humidity,
                DailySolarHours = request.LightTime
            };

            return settings;
        }

        public TraySettingsResponse ConvertToResponse(TraySettings settings)
        {
            TraySettingsResponse response = new()
            {
                RegisterDate = settings.RegisterDate,
                TemperatureCelsius = settings.TemperatureCelsius,
                Humidity = (int)settings.Humidity,
                DailySolarHours = settings.DailySolarHours,
            };

            return response;
        }

        public TrayInitialConfigurationResponse ConvertToResponse(TraySettings settings, TraySensorReadingDTO readingsDTO)
        {
            TrayInitialConfigurationResponse response = new()
            {
                RegisterDate = settings.RegisterDate,
                TemperatureCelsius = settings.TemperatureCelsius,
                Humidity = (int)settings.Humidity,
                DailySolarHours = settings.DailySolarHours,
                TargetLightMinutes = settings.DailySolarHours * 60,
                DailyLightMinutes = readingsDTO.DailyLightMinutes,
                RemainingLightMinutes = readingsDTO.RemainingLightMinutes
            };

            return response;
        }
    }
}
