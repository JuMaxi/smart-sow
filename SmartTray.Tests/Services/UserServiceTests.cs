using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Domain.Services;

namespace SmartTray.Tests.Services
{
    public class UserServiceTests
    {
        // Verifying the GetById method is calling the interface repository method
        [Fact]
        public async void When_Calling_GetById_Method_It_Should_Receive_One_Call_To_The_Interface_UserRepository()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            await userService.GetById(5);

            await userRepositoryMock.Received(1).GetById(5);
        }

        // Verifying the Insert method is calling the interface repository method
        [Fact]
        public async void When_Calling_Insert_Method_It_Should_Receive_One_Call_To_The_Interface_UserRepository()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            UserDTO userDTO = new() { Id = 5, Password = "hgIt6s3£"};

            User user = new() { Id = userDTO.Id };

            await userRepositoryMock.Insert(user);

            await userService.Insert(userDTO);
            await userRepositoryMock.Received(1).Insert(user);
        }

        // Verifying the Insert method is not calling the interface repository when the userDTO is null
        [Fact]
        public async void When_Calling_Insert_Method_With_UserDTO_Null_It_Should_not_Call_The_Interface_UserRepository()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            await userService.Insert(null);

            await userRepositoryMock.Received(0).Insert(new User());

        }

        // Verifying the Insert method is calling the user repository interface method with the data from userDTO
        [Fact]
        public async void When_Calling_Insert_Method_It_Should_Receive_As_Parameter_A_User_With_The_UserDTO_data()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            UserDTO userDTO = new()
            {
                Name = "Juliana",
                Email = "juliana@email.com",
                Password = "hgIt6s3£",
                Postcode = "GTY-HST"
            };

            await userService.Insert(userDTO);

            await userRepositoryMock.Received(1).Insert(Arg.Is<User>(u => u.Name == userDTO.Name 
                && u.Email == userDTO.Email 
                && u.Postcode == userDTO.Postcode));
        }

        // Verifying the Update method is calling the interface user repository methods
        [Fact]
        public async void When_Calling_Update_Method_It_Should_Receive_One_Call_To_Each_The_Interface_UserRepository_Method()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            UserDTO userDTO = new();
            User user = new();

            userRepositoryMock.GetById(user.Id).Returns(user);

            await userService.Update(userDTO);

            await userRepositoryMock.Received(1).GetById(userDTO.Id);
            await userRepositoryMock.Received(1).Update(user);
        }

        // Verifying the Update method is not calling any interface user repository methods when userDTO is null
        [Fact]
        public async void When_Calling_Update_Method_And_UserDTO_Is_Null_It_Should_Not_Call_Any_Interface_UserRepository_Methods()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            await userService.Update(null);

            await userRepositoryMock.Received(0).GetById(0);
            await userRepositoryMock.Received(0).Update(null);
        }

        // Verifying the Update method if user as the same data received with userDTO parameter
        [Fact]
        public async void When_Calling_Update_The_User_Must_Have_Same_Data_Than_UserDTO()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            UserDTO userDTO = new()
            {
                Id = 1,
                Name = "Juliana",
                Email = "juliana@email.com",
                Postcode = "FGT-CDE"
            };

            User toUpdate = new() { Id = userDTO.Id};

            userRepositoryMock.GetById(userDTO.Id).Returns(toUpdate);

            await userService.Update(userDTO);

            toUpdate.Name.Should().Be(userDTO.Name);
            toUpdate.Email.Should().Be(userDTO.Email);
            toUpdate.Postcode.Should().Be(userDTO.Postcode);
        }

        // Verifying the Update method if user retrieved from database, it should not call the interface userRepository method to update it
        [Fact]
        public async void When_Calling_Update_Method_If_User_Retrieved_From_DataBase_Is_Null_It_Should_Not_Call_UserRepository_Method()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            UserDTO userDTO = new();

            userRepositoryMock.GetById(userDTO.Id).ReturnsNull();

            await userService.Update(userDTO);

            await userRepositoryMock.Received(0).Update(null);
        }

        // Verifying the Login method is calling the interface userRepository method
        [Fact]
        public async void When_Calling_Login_It_Should_Receive_One_Call_To_The_Interface_UserRepository()
        {
            IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();

            UserService userService = new(userRepositoryMock);

            User user = new()
            {
                Id = 1,
                Email = "juliana@email.com",
            };

            userRepositoryMock.GetByEmail(user.Email).Returns(user);

            await userService.Login(user.Email, "hgIt6s3£");

            await userRepositoryMock.Received(1).GetByEmail(user.Email);
        }
    }
}
