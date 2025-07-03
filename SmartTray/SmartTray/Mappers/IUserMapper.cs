using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.API.Mappers
{
    public interface IUserMapper
    {
        /// <summary>
        /// Receiving a request from the user (Front-end -> endpoint Controller) than converting it to Entity (User model) to 
        /// receive it into service and conect/work with the database(repository)
        /// </summary>
        /// <param name="request">The request model</param>
        /// <returns>User dto</returns>
        public UserDTO ConvertToUserDTO(UserRequest request);

        /// <summary>
        /// Receiving a user entity from the database (user requesting the account data for example) 
        /// via controller (GET) and converting it to a user response before returning to the user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User response</returns>
        public UserResponse ConvertToResponse(User user);
    }
}
