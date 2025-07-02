using Microsoft.AspNetCore.Mvc;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IUserMapper _userMapper;

        public UserController(
            IUserService userService,
            IUserMapper userMapper)
        {
            _userService = userService;
            _userMapper = userMapper;
        }

        // This method stores the user data (creating account) to the database
        [HttpPost]
        public async Task Insert(UserRequest userRequest)
        {
            await _userService.Insert(_userMapper.ConvertToUser(userRequest));
        }

        // This method fetch the user data stored into the database 
        [HttpGet("{id}")]
        public async Task<UserResponse> GetById([FromRoute] int id)
        {
            User user = await _userService.GetById(id);

            return _userMapper.ConvertToResponse(user);
        }

        // This method updates the user data (account)
        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UserRequest userRequest)
        {
            User user = _userMapper.ConvertToUser(userRequest);
            user.Id = id;

            await _userService.Update(user);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            //await _userService.Delete(id);
        }
    }
}
