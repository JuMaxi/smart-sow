using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class TraySettingsMapper : ITraySettingsMapper
    {
        public TraySettings ConvertToGrowthSettings(TraySettingsRequest request)
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
                DailySolarHours = settings.DailySolarHours
            };

            return response;
        }
    }
}
