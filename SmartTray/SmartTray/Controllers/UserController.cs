using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
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
        public async Task Insert(CreateUserRequest userRequest)
        {
            await _userService.Insert(_userMapper.ConvertToUserDTO(userRequest));
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
        public async Task Update([FromRoute] int id, [FromBody] UpdateUserRequest userRequest)
        {
            UserDTO userDTO = _userMapper.ConvertToUserDTO(userRequest);
            userDTO.Id = id;

            await _userService.Update(userDTO);
        }

        // This method is checking the user login (email and password).
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            LoginResult result = await _userService.Login(login.Email, login.Password);

            if (result.Success)
            {
                List<Claim> claim =
                [
                    new (ClaimTypes.NameIdentifier, result.User.Id.ToString())
                ];

                var claimsId = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsId));

                return Ok();
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            //await _userService.Delete(id);
        }
    }
}
