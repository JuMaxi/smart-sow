using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public class UserMapper : IUserMapper
    {
        /*
            The controller doesn't communicate directly with the service class, it receives a request or response,
            then these methods are below are converting it to user or user response
        */

        /*
            Receiving a request from the user (Front-end -> endpoint Controller) than converting it to Entity (User model) to 
            receive it into service and conect/work with the database (repository)
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

        // 
        public UserResponse ConvertToResponse(User user)
        {

        }
    }
}
