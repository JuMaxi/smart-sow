using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class UserMapper : IUserMapper
    {
        /*
            The controller doesn't communicate directly with the service class, it receives a request or response,
            then these methods are below are converting it to user or user response. See the comments on the interfaces or controller methods.
        */

        public User ConvertToUser(UserRequest request)
        {
            User user = new()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
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
                Password = user.Password,
                Postcode = user.Password
            };

            return response;
        }
    }
}
