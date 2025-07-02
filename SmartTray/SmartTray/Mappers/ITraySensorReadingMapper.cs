using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public interface ITraySensorReadingMapper
    {
        public TraySensorReading ConvertToTraySensorReading(TraySensorReadingRequest request);
        public TraySensorReadingResponse ConvertToResponse(TraySensorReading reading);
        public List<TraySensorReadingResponse> ConvertToResponseList(List<TraySensorReading> readings);
    }
}
