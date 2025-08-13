using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using SmartTray.Domain.Interfaces;
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
    }
}
