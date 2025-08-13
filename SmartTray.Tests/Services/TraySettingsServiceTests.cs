using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
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
