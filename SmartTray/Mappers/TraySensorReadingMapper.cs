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
                Date = DateTime.UtcNow,
                Temperature = Convert.ToInt32(request.Temperature),
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
            TraySensorReadingResponse response = new();

            // In case the user has just inserted a new tray and click in display its data, there is no sensor readings to display the last readings
            if (reading == null)
            {
                response.Date = DateTime.UtcNow;
                response.Temperature = 0;
                response.Humidity = 0;
                response.UvReading = 0;
            }
            else
            {
                response.Date = reading.Date;
                response.Temperature = reading.Temperature;
                response.Humidity = reading.Humidity;
                response.UvReading = reading.UV;
                response.WaterAdded = reading.WaterAdded;
                response.UvLedsOn = reading.UvLedsOn;
                response.HeatingMatOn = reading.HeatingMatOn;
            }
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
            TraySensorReadingDTOResponse response = new();

            if (readings  == null)
            {
                response.DailyLightMinutes = 0;
                response.ArtificialLightMinutes = 0;
                response.SolarLightMinutes = 0;
                response.RemainingLightMinutes = 0;
                response.Humidity = 0;
            }
            else
            {
                response.DailyLightMinutes = readings.DailyLightMinutes;
                response.ArtificialLightMinutes = readings.ArtificialLightMinutes;
                response.SolarLightMinutes = readings.SolarLightMinutes;
                response.RemainingLightMinutes = readings.RemainingLightMinutes;
                response.Humidity = readings.Humidity;
            }

            return response;
        }
    }
}
