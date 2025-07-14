using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class UserMapper : IUserMapper
    {
        /*
            The controller doesn't communicate directly with the service class, it receives a request or response,
            then these methods are below are converting it to user or user response. See the comments on the interfaces or controller methods.
        */

        public UserDTO ConvertToUserDTO(CreateUserRequest request)
        {
            UserDTO user = new()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Postcode = request.Postcode
            };

            return user;
        }

        // I am using creating this method, because the password is not being updated this time, so the need to separate create user and update user
        public UserDTO ConvertToUserDTO(UpdateUserRequest request)
        {
            UserDTO user = new()
            {
                Name = request.Name,
                Email = request.Email,
                Postcode = request.Postcode
            };

            return user;
        }

        public UserResponse ConvertToResponse(User user)
        {
            UserResponse response = new()
            {
                Name = user.Name,
                Email = user.Email,
                Postcode = user.Postcode
            };

            return response;
        }
    }
}
