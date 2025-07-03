using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public interface ITraySettingsMapper
    {
        public TraySettings ConvertToGrowthSettings(TraySettingsRequest request);
        public TraySettingsResponse ConvertToResponse(TraySettings settings);
    }
}
