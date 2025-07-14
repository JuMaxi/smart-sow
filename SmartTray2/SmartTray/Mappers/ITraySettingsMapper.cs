using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public interface ITraySettingsMapper
    {
        public TraySettings ConvertToTraySettings(TraySettingsRequest request);
        public TraySettingsResponse ConvertToResponse(TraySettings settings);
        public TrayInitialConfigurationResponse ConvertToResponse(TraySettings settings, TraySensorReadingDTO readingsDTO);
    }
}
