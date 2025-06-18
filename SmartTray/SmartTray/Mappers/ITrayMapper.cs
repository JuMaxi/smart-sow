using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public interface ITrayMapper
    {
        public Tray ConvertFromRequest(TrayRequest request);
        public TrayResponse ConvertToResponse(Tray tray);
        public List<TrayResponse> ConvertListToResponse(List<Tray> trays);
    }
}
