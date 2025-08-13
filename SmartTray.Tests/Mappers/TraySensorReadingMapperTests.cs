
using FluentAssertions;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.Tests.Mappers
{
    public class TraySensorReadingMapperTests
    {
        [Fact]
        public void When_Converting_TraySensorReadingRequest_It_Should_Be_Equal_TraySensorReading()
        {
            TraySensorReadingRequest readingsRequest = new()
            {
                Temperature = 25,
                Humidity = 3000,
                UvReading = 4096,
                WaterAdded = true, 
                UvLedsOn = false,
                HeatingMatOn = false
            };

            TraySensorReadingMapper readingsMapper = new();

            TraySensorReading traySensorReading = readingsMapper.ConvertToTraySensorReading(readingsRequest);

            traySensorReading.Date.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            traySensorReading.Temperature.Should().Be(Convert.ToInt32(readingsRequest.Temperature));
            traySensorReading.Humidity.Should().Be(readingsRequest.Humidity);
            traySensorReading.UV.Should().Be(readingsRequest.UvReading);
            traySensorReading.WaterAdded.Should().Be(readingsRequest.WaterAdded);
            traySensorReading.UvLedsOn.Should().Be(readingsRequest.UvLedsOn);
            traySensorReading.HeatingMatOn.Should().Be(readingsRequest.HeatingMatOn);
        }

        [Fact]
        public void When_Converting_TraySensorReadingNull_It_Should_Be_Equal_TraySensorReadingResponse()
        {
            TraySensorReadingMapper readingsMapper = new();

            TraySensorReadingResponse traySensorReading = readingsMapper.ConvertToResponse(null);

            traySensorReading.Date.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            traySensorReading.Temperature.Should().Be(0);
            traySensorReading.Humidity.Should().Be(0);
            traySensorReading.UvReading.Should().Be(0);

        }

        [Fact]
        public void When_Converting_TraySensorReading_It_Should_Be_Equal_TraySensorReadingResponse()
        {
            TraySensorReading traySensorReading = new()
            {
                Date = DateTime.Now,
                Temperature = 25, 
                Humidity = 3000,
                UV = 4096,
                WaterAdded = true, 
                UvLedsOn = false, 
                HeatingMatOn = false
            };

            TraySensorReadingMapper readingsMapper = new();

            TraySensorReadingResponse readingsResponse = readingsMapper.ConvertToResponse(traySensorReading);

            readingsResponse.Date.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            readingsResponse.Temperature.Should().Be(traySensorReading.Temperature);
            readingsResponse.Humidity.Should().Be(traySensorReading.Humidity);
            readingsResponse.UvReading.Should().Be(traySensorReading.UV);
            readingsResponse.WaterAdded.Should().Be(traySensorReading.WaterAdded);
            readingsResponse.UvLedsOn.Should().Be(traySensorReading.UvLedsOn);
            readingsResponse.HeatingMatOn.Should().Be(traySensorReading.HeatingMatOn);

        }

        [Fact]
        public void When_Converting_List_TraySensorReading_It_Should_Be_Equal_List_TraySensorReadingResponse()
        {
            List<TraySensorReading> traySensorReadings = new()
            {
                new TraySensorReading()
                {
                    Date = DateTime.Now,
                    Temperature = 25,
                    Humidity = 3000,
                    UV = 4096,
                    WaterAdded = true,
                    UvLedsOn = false,
                    HeatingMatOn = false
                },
                new TraySensorReading()
                {
                    Date = DateTime.Now,
                    Temperature = 23,
                    Humidity = 2500,
                    UV = 4000,
                    WaterAdded = false,
                    UvLedsOn = false,
                    HeatingMatOn = false
                }
            };

            TraySensorReadingMapper readingMapper = new();

            List<TraySensorReadingResponse> readingsResponse = readingMapper.ConvertToResponseList(traySensorReadings);

            // Index 0
            readingsResponse[0].Date.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            readingsResponse[0].Temperature.Should().Be(traySensorReadings[0].Temperature);
            readingsResponse[0].Humidity.Should().Be(traySensorReadings[0].Humidity);
            readingsResponse[0].UvReading.Should().Be(traySensorReadings[0].UV);
            readingsResponse[0].WaterAdded.Should().Be(traySensorReadings[0].WaterAdded);
            readingsResponse[0].UvLedsOn.Should().Be(traySensorReadings[0].UvLedsOn);
            readingsResponse[0].HeatingMatOn.Should().Be(traySensorReadings[0].HeatingMatOn);

            // Index 1
            readingsResponse[1].Date.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            readingsResponse[1].Temperature.Should().Be(traySensorReadings[1].Temperature);
            readingsResponse[1].Humidity.Should().Be(traySensorReadings[1].Humidity);
            readingsResponse[1].UvReading.Should().Be(traySensorReadings[1].UV);
            readingsResponse[1].WaterAdded.Should().Be(traySensorReadings[1].WaterAdded);
            readingsResponse[1].UvLedsOn.Should().Be(traySensorReadings[1].UvLedsOn);
            readingsResponse[1].HeatingMatOn.Should().Be(traySensorReadings[1].HeatingMatOn);
        }

        [Fact]
        public void When_Converting_TraySensorReadingDTONull_It_Should_Be_Equal_TraySensorReadingDTOResponse()
        {
            TraySensorReadingMapper readingsMapper = new();

            TraySensorReadingDTOResponse readingsDTOResponse = readingsMapper.ConvertToDTOResponse(null);

            readingsDTOResponse.DailyLightMinutes.Should().Be(0);
            readingsDTOResponse.ArtificialLightMinutes.Should().Be(0);
            readingsDTOResponse.SolarLightMinutes.Should().Be(0);
            readingsDTOResponse.RemainingLightMinutes.Should().Be(0);
            readingsDTOResponse.Humidity.Should().Be(0);
        }

        [Fact]
        public void When_Converting_TraySensorReadingDTO_It_Should_Be_Equal_TraySensorReadingDTOResponse()
        {
            TraySensorReadingDTO sensorReadingDTO = new()
            {
                DailyLightMinutes = 960,
                ArtificialLightMinutes = 200,
                SolarLightMinutes = 700,
                RemainingLightMinutes = 60,
                Humidity = 2100
            };

            TraySensorReadingMapper readingsMapper = new();

            TraySensorReadingDTOResponse readingsDTOResponse = readingsMapper.ConvertToDTOResponse(sensorReadingDTO);

            readingsDTOResponse.DailyLightMinutes.Should().Be(sensorReadingDTO.DailyLightMinutes);
            readingsDTOResponse.ArtificialLightMinutes.Should().Be(sensorReadingDTO.ArtificialLightMinutes);
            readingsDTOResponse.SolarLightMinutes.Should().Be(sensorReadingDTO.SolarLightMinutes);
            readingsDTOResponse.RemainingLightMinutes.Should().Be(sensorReadingDTO.RemainingLightMinutes);
            readingsDTOResponse.Humidity.Should().Be(sensorReadingDTO.Humidity);
        }
    }
}
