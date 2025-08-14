using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Domain.Services;

namespace SmartTray.Tests.Services
{
    public class TrayServiceTests
    {
        // Verifying the GetByIdAndToken method is calling the interface repository method
        [Fact]
        public async void When_Calling_GetByIdAndToken_Method_It_Should_Receive_One_Call_To_The_Interface_TrayRepository()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            TrayService trayService = new(trayRepositoryMock, null);

            await trayService.GetByIdAndToken(1, "HgTf9v4a7");

            await trayRepositoryMock.Received(1).GetByIdAndToken(1, "HgTf9v4a7");
        }

        // Verifying the GetById method is calling the interface repository method
        [Fact]
        public async void When_Calling_GetById_Method_It_Should_Receive_One_Call_To_The_Interface_TrayRepository()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            TrayService trayService = new(trayRepositoryMock, null);

            await trayService.GetById(1, 5);

            await trayRepositoryMock.Received(1).GetById(1, 5);
        }

        // Verifying the GetAll method is calling the interface repository method
        [Fact]
        public async void When_Calling_GeAll_Method_It_Should_Receive_One_Call_To_The_Interface_TrayRepository()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            TrayService trayService = new(trayRepositoryMock, null);

            await trayService.GetAll(5);

            await trayRepositoryMock.Received(1).GetAll(5);
        }

        // Verifying the Update method is calling the interface repository to the tray repository methods
        [Fact]
        public async void When_Calling_Update_Method_It_Should_Receive_One_Call_To_The_Interface_TrayRepository_In_Each_Method()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            TrayService trayService = new(trayRepositoryMock, null);

            Tray tray = new() { Id = 1, User = new() { Id = 5}, Settings = new() };

            Tray toUpdate = new() { Id = 1, User = new() { Id = 5 } };

            trayRepositoryMock.GetById(tray.Id, tray.User.Id).Returns(toUpdate);

            await trayService.Update(tray, tray.User.Id);

            await trayRepositoryMock.Received(1).GetById(tray.Id, tray.User.Id);
            await trayRepositoryMock.Received(1).Update(toUpdate);
        }

        // Verifying the Update method is updating the tray retrieved from database with the new tray data
        [Fact]
        public async void When_Calling_Update_Method_It_Should_Update_Data_To_Tray_Retrieved_From_DataBase()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            TrayService trayService = new(trayRepositoryMock, null);

            Tray tray = new()
            {
                Id = 1,
                Name = "My First Tray",
                CropType = "Basil",
                SowingDate = DateTime.UtcNow,
                Settings = new()
                {
                    TemperatureCelsius = 25,
                    Humidity = HumidityLevel.MediumHumidity,
                    DailySolarHours = 10
                },
                User = new()
                {
                    Id = 5
                }
            };

            Tray toUpdate = new() { Id = tray.Id}, User = new() { Id = tray.User.Id};

            trayRepositoryMock.GetById(tray.Id, tray.User.Id).Returns(toUpdate);

            await trayService.Update(tray, tray.User.Id);

            toUpdate.Name.Should().Be(tray.Name);
            toUpdate.CropType.Should().Be(tray.CropType);
            toUpdate.SowingDate.Should().BeCloseTo(tray.SowingDate, TimeSpan.FromSeconds(1));
            toUpdate.Settings.TemperatureCelsius.Should().Be(tray.Settings.TemperatureCelsius);
            toUpdate.Settings.Humidity.Should().Be(tray.Settings.Humidity);
            toUpdate.Settings.DailySolarHours.Should().Be(tray.Settings.DailySolarHours);
        }

        // Verifying the Deactivate method is calling the interface repository to the tray repository methods
        [Fact]
        public async void When_Calling_Deactivate_Method_It_Should_Receive_One_Call_To_The_Interface_TrayRepository_In_Each_Method()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            TrayService trayService = new(trayRepositoryMock, null);

            Tray tray = new() { Id = 1, User = new() { Id = 5 } };

            Tray updateStatus = new() { Id = tray.Id, User = new() { Id = tray.User.Id } };

            trayRepositoryMock.GetById(tray.Id, tray.User.Id).Returns(updateStatus);

            await trayService.Deactivate(tray.Id, tray.User.Id);
            await trayRepositoryMock.Received(1).GetById(tray.Id, tray.User.Id);
            await trayRepositoryMock.Received(1).UpdateStatus(updateStatus);
        }

        // Verifying the Deactivate method when the tray is null
        [Fact]
        public async void When_Calling_The_Deactivate_Method_If_Tray_Is_Null_It_Should_Not_Update_The_TrayStatus()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            TrayService trayService = new(trayRepositoryMock, null);

            trayRepositoryMock.GetById(0, 0).ReturnsNull();

            await trayService.Deactivate(0, 0);
            await trayRepositoryMock.Received(0).UpdateStatus(null);
        }
    }
}
