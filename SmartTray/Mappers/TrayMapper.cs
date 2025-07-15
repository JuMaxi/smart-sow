using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class TrayMapper : ITrayMapper
    {
        ITraySettingsMapper _settingsMapper;

        public TrayMapper(ITraySettingsMapper settingsMapper)
        {
            _settingsMapper = settingsMapper;
        }

        public Tray ConvertToTray(TrayRequest request)
        {
            TraySettings settings = _settingsMapper.ConvertToTraySettings(request.settings);
            Tray tray = new()
            {
                Name = request.Name,
                CropType = request.CropType,
                SowingDate = DateTime.SpecifyKind(request.SowingDate, DateTimeKind.Utc),
                Settings = settings
            };

            return tray;
        }

        public TrayResponse ConvertToResponse(Tray tray)
        {
            TraySettingsResponse settingsResponse = _settingsMapper.ConvertToResponse(tray.Settings);
            TrayResponse response = new()
            {
                Id = tray.Id,
                Name = tray.Name,
                CropType = tray.CropType,
                SowingDate = tray.SowingDate,
                Settings = settingsResponse,
                Token = tray.Token
            };

            return response;
        }

        public List<TrayResponse> ConvertToResponseList(List<Tray> trays)
        {
            List<TrayResponse> responses = new();

            foreach(Tray tray in trays)
            {
                TrayResponse response = new()
                {
                    Id = tray.Id,
                    Name = tray.Name,
                    CropType = tray.CropType,
                    SowingDate = tray.SowingDate,
                    Status = tray.Status.ToString(),
                    Token = tray.Token
                };

                responses.Add(response);
            }

            return responses;
        }
    }
}
