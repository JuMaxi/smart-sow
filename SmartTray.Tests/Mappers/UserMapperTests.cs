
using FluentAssertions;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.Tests.Mappers
{
    public class UserMapperTests
    {
        [Fact]
        public void When_Converting_Create_User_Request_It_Should_Be_Equal_User_DTO()
        {
            CreateUserRequest userRequest = new()
            {
                Name = "Juliana",
                Email = "juliana@email.com",
                Password = "Hy8to$p",
                Postcode = "WSO-PGT"
            };

            UserMapper userMapper = new();

            UserDTO userDTO = userMapper.ConvertToUserDTO(userRequest);

            userDTO.Name.Should().Be(userRequest.Name);
            userDTO.Email.Should().Be(userRequest.Email);
            userDTO.Password.Should().Be(userRequest.Password);
            userDTO.Postcode.Should().Be(userRequest.Postcode);
        }

        [Fact]
        public void When_Converting_Update_User_Request_It_Should_Be_Equal_User_DTO()
        {
            UpdateUserRequest userRequest = new()
            {
                Name = "Juliana",
                Email = "juliana@email.com",
                Postcode = "WSO-PGT"
            };

            UserMapper userMapper = new();

            UserDTO userDTO = userMapper.ConvertToUserDTO(userRequest);

            userDTO.Name.Should().Be(userRequest.Name);
            userDTO.Email.Should().Be(userRequest.Email);
            userDTO.Postcode.Should().Be(userRequest.Postcode);
        }

        [Fact]
        public void When_Converting_User_It_Should_Be_Equal_User_Response()
        {
            User user = new()
            {
                Name = "Juliana",
                Email = "juliana@email.com",
                Postcode = "WSO-PGT"
            };

            UserMapper userMapper = new();

            UserResponse userResponse = userMapper.ConvertToResponse(user);

            userResponse.Name.Should().Be(user.Name);
            userResponse.Email.Should().Be(user.Email);
            userResponse.Postcode.Should().Be(user.Postcode);
        }

    }
}
