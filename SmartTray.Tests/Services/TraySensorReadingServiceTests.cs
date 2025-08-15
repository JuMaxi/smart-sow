
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Domain.Services;

namespace SmartTray.Tests.Services
{
    public class TraySensorReadingServiceTests
    {
        // Verifying while calling Insert method if there is a call to trayRepository Interface
        [Fact]
        public async void When_Calling_Insert_Method_It_Should_Receive_One_Call_To_The_Interface_TrayRepository()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            TraySensorReadingService traySensorReadingService = new(null, trayRepositoryMock);

            trayRepositoryMock.GetByIdAndToken(1, "Jgt50Op3D").ReturnsNull();

            TraySensorReading traySensorReading = new();

            await traySensorReadingService.Insert(1, "Jgt50Op3D", traySensorReading);

            await trayRepositoryMock.Received(1).GetByIdAndToken(1, "Jgt50Op3D");
        }

        // Verifying while calling the insert method if there is a call to traySensorReadingRepository Interface
        [Fact]
        public async void When_Calling_Insert_Method_It_Should_Receive_One_Call_To_The_Interface_TraySensorReadindRepository()
        {
            ITrayRepository trayRepositoryMock = Substitute.For<ITrayRepository>();

            ITraySensorReadingRepository traySensorReadingRepositoryMock = Substitute.For<ITraySensorReadingRepository>();

            TraySensorReadingService traySensorReadingService = new(traySensorReadingRepositoryMock, trayRepositoryMock);

            Tray tray = new() { Id = 1, Token = "Jgt50Op3D" };
            trayRepositoryMock.GetByIdAndToken(1, "Jgt50Op3D").Returns(tray);

            TraySensorReading traySensorReading = new();

            await traySensorReadingService.Insert(1, "Jgt50Op3D", traySensorReading);

            await traySensorReadingRepositoryMock.Received(1).Insert(traySensorReading);

        }

        // Verifying while calling the GetAll method if there is a call to traySensorReadingRepository
        [Fact]
        public async void When_Calling_GetAll_Method_It_Should_Receive_One_Call_To_The_Interface_TraySensorReadindRepository()
        {
            ITraySensorReadingRepository traySensorReadingRepositoryMock = Substitute.For<ITraySensorReadingRepository>();

            TraySensorReadingService traySensorReadindService = new(traySensorReadingRepositoryMock, null);

            await traySensorReadindService.GetAll(1, 1);

            await traySensorReadingRepositoryMock.Received(1).GetAll(1, 1);
        }

        // Verifying while calling the GetLatest method if there is a call to traySensorReadingRepository
        [Fact]
        public async void When_Calling_GetLatest_Method_It_Should_Receive_One_Call_To_The_Interface_TraySensorReadingRepository()
        {
            ITraySensorReadingRepository traySensorReadingRepositoryMock = Substitute.For<ITraySensorReadingRepository>();

            TraySensorReadingService traySensorReadingService = new(traySensorReadingRepositoryMock, null);

            await traySensorReadingService.GetLatest(1, 1);

            await traySensorReadingRepositoryMock.Received(1).GetLatest(1, 1);
        }

        // Verifying while calling the GetDayReadings method if there is a call to traySensorReadingRepository
        [Fact]
        public async void When_Calling_GetDayReadings_Method_It_Should_Receive_One_Call_To_The_Interface_TraySensorReadingRepository()
        {
            ITraySensorReadingRepository traySensorReadingRepositoryMock = Substitute.For<ITraySensorReadingRepository>();

            TraySensorReadingService traySensorReadingService = new(traySensorReadingRepositoryMock, null);

            DateTime date = DateTime.UtcNow;

            await traySensorReadingService.GetDayReadings(1, 1, date);

            await traySensorReadingRepositoryMock.Received(1).GetDayReadings(1, 1, date);
        }
    }
}
