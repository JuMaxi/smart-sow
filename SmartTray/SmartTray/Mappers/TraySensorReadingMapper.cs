using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class TraySensorReadingMapper : ITraySensorReadingMapper
    {
        public TraySensorReading ConvertToTraySensorReading(TraySensorReadingRequest request)
        {
            TraySensorReading reading = new()
            {
                Date = request.Date,
                Temperature = request.Temperature,
                Humidity = request.Humidity,
                UV = request.UvReading,
                WaterAdded = request.WaterAdded,
                UvLedsOn = request.UvLedsOn,
                HeatingMatOn = request.HeatingMatOn
            };

            return reading;
        }

        public TraySensorReadingResponse ConvertToResponse(TraySensorReading reading)
        {
            TraySensorReadingResponse response = new()
            {
                Date = reading.Date,
                Temperature = reading.Temperature,
                Humidity = reading.Humidity,
                UvReading = reading.UV,
                WaterAdded = reading.WaterAdded,
                UvLedsOn = reading.UvLedsOn,
                HeatingMatOn = reading.HeatingMatOn
            };

            return response;
        }

        public List<TraySensorReadingResponse> ConvertToResponseList(List<TraySensorReading> readings)
        {
            List<TraySensorReadingResponse> responses = new();

            foreach(TraySensorReading reading in readings)
            {
                TraySensorReadingResponse response = new()
                {
                    Date = reading.Date,
                    Temperature = reading.Temperature,
                    Humidity = reading.Humidity,
                    UvReading = reading.UV,
                    WaterAdded = reading.WaterAdded,
                    UvLedsOn = reading.UvLedsOn,
                    HeatingMatOn = reading.HeatingMatOn
                };

                responses.Add(response);
            }
            return responses;
        }

        public TraySensorReadingDTOResponse ConvertToDTOResponse(TraySensorReadingDTO readings)
        {
            TraySensorReadingDTOResponse response = new()
            {
                TargetLightMinutes = readings.TargetLightMinutes,
                DailyLightMinutes = readings.DailyLightMinutes,
                ArtificialLightMinutes = readings.ArtificialLightMinutes,
                SolarLightMinutes = readings.SolarLightMinutes,
                RemainingLightMinutes = readings.RemainingLightMinutes,
            };

            return response;
        }
    }
}
