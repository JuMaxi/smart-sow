using NSubstitute;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Services;

namespace SmartTray.Tests.Services
{
    public class UserServiceTests
    {
        // Verifying the GetById method is calling the interface repository method
        [Fact]
        public async void When_Calling_GetById_Method_It_Should_Receive_One_Call_To_The_Interface_TrayRepository()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            await userService.GetById(5);

            await userRepositoryMock.Received(1).GetById(5);
        }
    }
}
