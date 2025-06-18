using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public interface IGrowthSettingsMapper
    {
        public GrowthSettings ConvertFromRequest(GrowthSettingsRequest request);
        public GrowthSettingsResponse ConvertToResponse(GrowthSettings settings);
    }
}
