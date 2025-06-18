using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class GrowthSettingsMapper : IGrowthSettingsMapper
    {
        public GrowthSettings ConvertFromRequest(GrowthSettingsRequest request)
        {
            GrowthSettings settings = new()
            {
                RegisterDate = DateTime.Now,
                TemperatureCelsius = request.Temperature,
                Humidity = request.Humidity,
                DailySolarHours = request.LightTime
            };

            return settings;
        }

        public GrowthSettingsResponse ConvertToResponse(GrowthSettings settings)
        {
            GrowthSettingsResponse response = new()
            {
                RegisterDate = settings.RegisterDate,
                TemperatureCelsius = settings.TemperatureCelsius,
                Humidity = settings.Humidity,
                DailySolarHours = settings.DailySolarHours
            };

            return response;
        }
    }
}
