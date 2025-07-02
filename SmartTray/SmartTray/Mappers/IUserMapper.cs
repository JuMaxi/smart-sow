using SmartTray.API.Models.Requests;
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
        /// <returns>User entity</returns>
        User ConvertToUser(UserRequest request);
    }
}
