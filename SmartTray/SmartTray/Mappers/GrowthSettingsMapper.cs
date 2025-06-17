using SmartTray.API.Models.Requests;
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
    }
}
