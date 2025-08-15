using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Domain.Services;

namespace SmartTray.Tests.Services
{
    public class TraySettingsServiceTests
    {
        // Verifying the Insert method is calling the interface repository method
        [Fact]
        public async void When_Calling_Insert_Method_It_Should_Receive_One_Call_To_Interface_Method()
        {
            ITraySettingsRepository traySettingsRepositoryMock = Substitute.For<ITraySettingsRepository>();

            TraySettingsService traySettingsService = new(traySettingsRepositoryMock);

            TraySettings traySettings = new();

            await traySettingsService.Insert(traySettings);

            await traySettingsRepositoryMock.Received(1).Insert(traySettings);
        }

        // Verifying the Insert method is receiving as parameter a traySettingService null not call the interface repository method
        [Fact]
        public async void When_Calling_Insert_Method_It_Should_Not_Receive_One_Call_To_Interface_Method()
        {
            ITraySettingsRepository traySettingsRepositoryMock = Substitute.For<ITraySettingsRepository>();

            TraySettingsService traySettingsService = new(traySettingsRepositoryMock);

            await traySettingsService.Insert(null);

            await traySettingsRepositoryMock.Received(0).Insert(null);
        }

        // Verifying the GetById method is calling the interface repository method
        [Fact]
        public async void When_Calling_GetById_Method_It_Should_Receive_One_Call_To_Interface_Method()
        {
            ITraySettingsRepository traySettingsRepositoryMock = Substitute.For<ITraySettingsRepository>();

            TraySettingsService traySettingsService = new(traySettingsRepositoryMock);

            TraySettings traySettings = new() { Id = 1 };

            await traySettingsService.GetById(traySettings.Id);

            await traySettingsRepositoryMock.Received(1).GetById(traySettings.Id);
        }

        // Verifying the Update method is calling the interface repository methods
        [Fact]
        public async void When_Calling_Update_It_Should_Receive_One_Call_To_Each_Interface_Method()
        {
            ITraySettingsRepository traySettingsRepositoryMock = Substitute.For<ITraySettingsRepository>();

            TraySettingsService traySettingsService = new(traySettingsRepositoryMock);

            TraySettings traySettings = new();

            TraySettings toUpdate = new();

            traySettingsRepositoryMock.GetById(traySettings.Id).Returns(toUpdate);

            await traySettingsService.Update(traySettings);

            await traySettingsRepositoryMock.Received(1).GetById(traySettings.Id);
            await traySettingsRepositoryMock.Received(1).Update(toUpdate);
        }

        // Verifying the Update method when the tray settings received as parameter is null can't have any interface repository call
        [Fact]
        public async void When_Calling_Update_Method_If_Parameter_Received_Is_Null_Should_Not_Receive_Call_To_Interface_Method()
        {
            ITraySettingsRepository traySettingsRepositoryMock = Substitute.For<ITraySettingsRepository>();

            TraySettingsService traySettingsService = new(traySettingsRepositoryMock);

            await traySettingsService.Update(null);

            await traySettingsRepositoryMock.Received(0).GetById(0);
            await traySettingsRepositoryMock.Received(0).Update(null);
        }

        // Verifying the Update method if data received as parameter is the same than data to be updated
        [Fact]
        public async void When_Calling_Update_Method_Data_Received_As_Parameter_Should_Be_Equal_Data_Be_Updated()
        {
            ITraySettingsRepository traySettingsRepositoryMock = Substitute.For<ITraySettingsRepository>();

            TraySettingsService traySettingsService = new(traySettingsRepositoryMock);

            TraySettings traySettings = new()
            {
                Id = 1,
                TemperatureCelsius = 25,
                Humidity = HumidityLevel.MediumHumidity,
                DailySolarHours = 12
            };

            TraySettings toUpdate = new();

            traySettingsRepositoryMock.GetById(traySettings.Id).Returns(toUpdate);

            await traySettingsService.Update(traySettings);

            toUpdate.TemperatureCelsius.Should().Be(traySettings.TemperatureCelsius);
            toUpdate.Humidity.Should().Be(traySettings.Humidity);
            toUpdate.DailySolarHours.Should().Be(traySettings.DailySolarHours);
        }

        // Verifying the Delete method is calling the interface repository method
        [Fact]
        public async void When_Calling_Delete_Method_It_Should_Receive_One_Call_To_Interface_Method()
        {
            ITraySettingsRepository traySettingsRepositoryMock = Substitute.For<ITraySettingsRepository>();

            TraySettingsService traySettingsService = new(traySettingsRepositoryMock);

            TraySettings traySettings = new() { Id = 1 };

            await traySettingsService.Delete(traySettings.Id);

            await traySettingsRepositoryMock.Received(1).Delete(traySettings.Id);
        }
    }
}
