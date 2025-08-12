
using System.Reflection.Emit;
using FluentAssertions;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.Tests.Mappers
{
    public class TraySettingsTests
    {
        [Fact]
        public void When_Converting_Tray_Settings_Request_It_Should_Be_Equal_Tray_Settings()
        {
            TraySettingsRequest settingsRequest = new()
            {
                Temperature = 25,
                Humidity = 1,
                LightTime = 12
            };

            TraySettingsMapper traySettingsMapper = new();

            TraySettings traySettings = traySettingsMapper.ConvertToTraySettings(settingsRequest);

            traySettings.TemperatureCelsius.Should().Be(settingsRequest.Temperature);
            traySettings.Humidity.Should().Be((HumidityLevel)settingsRequest.Humidity);
            traySettings.DailySolarHours.Should().Be(settingsRequest.LightTime);
            traySettings.RegisterDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void When_Converting_Tray_Settings_It_Should_Be_Equal_Tray_Settings_Response()
        {
            TraySettings traySettings = new()
            {
                RegisterDate = DateTime.Now,
                TemperatureCelsius = 25,
                Humidity = (HumidityLevel)1,
                DailySolarHours = 12
            };

            TraySettingsMapper traySettingsMapper = new();

            TraySettingsResponse settingsResponse = traySettingsMapper.ConvertToResponse(traySettings);

            settingsResponse.RegisterDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            settingsResponse.TemperatureCelsius.Should().Be(traySettings.TemperatureCelsius);
            settingsResponse.Humidity.Should().Be((int)traySettings.Humidity);
            settingsResponse.DailySolarHours.Should().Be(traySettings.DailySolarHours);
        }

        [Fact]
        public void When_Converting_Tray_Settings_And_Tray_Sensor_Readings_DTO_It_Should_Be_Equal_Tray_Initial_Configuration_Response()
        {
            TraySettings traySettings = new()
            {
                TemperatureCelsius = 25,
                DailySolarHours = 12
            };

            TraySensorReadingDTO traySensorReadingDTO = new()
            {
                Humidity = 1,
                DailyLightMinutes = 960,
                RemainingLightMinutes = 200,
            };

            TraySettingsMapper traySettingsMapper = new();

            TrayInitialConfigurationResponse trayResponse = traySettingsMapper.ConvertToResponse(traySettings, traySensorReadingDTO);

            trayResponse.TemperatureCelsius.Should().Be(traySettings.TemperatureCelsius);
            trayResponse.DailySolarHours.Should().Be(traySettings.DailySolarHours);
            trayResponse.Humidity.Should().Be(traySensorReadingDTO.Humidity);
            trayResponse.DailyLightMinutes.Should().Be(traySensorReadingDTO.DailyLightMinutes);
            trayResponse.RemainingLightMinutes.Should().Be(traySensorReadingDTO.RemainingLightMinutes);
            trayResponse.CurrentHour.Should().Be(DateTime.UtcNow.Hour);
        }
    }
}
