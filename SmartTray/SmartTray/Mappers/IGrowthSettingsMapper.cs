using SmartTray.API.Models.Requests;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public interface IGrowthSettingsMapper
    {
        public GrowthSettings ConvertFromRequest(GrowthSettingsRequest request);
    }
}
