using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class TrayMapper : ITrayMapper
    {
        public Tray ConvertToTray(TrayRequest request)
        {
            Tray tray = new()
            {
                Name = request.Name,
                CropType = request.CropType,
                SowingDate = request.SowingDate
            };

            return tray;
        }

        public TrayResponse ConvertToResponse(Tray tray)
        {
            TrayResponse response = new()
            {
                Name = tray.Name,
                CropType = tray.CropType,
                SowingDate = tray.SowingDate
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
                    Name = tray.Name,
                    CropType = tray.CropType,
                    SowingDate = tray.SowingDate
                };

                responses.Add(response);
            }

            return responses;
        }
    }
}
