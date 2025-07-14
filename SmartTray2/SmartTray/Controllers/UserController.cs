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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        [HttpGet]
        public async Task<UserResponse> GetById()
        {
            int id = GetUserId();
            User user = await _userService.GetById(id);

            return _userMapper.ConvertToResponse(user);
        }

        // This method is returning the user Id once it is authenticated. The claimtypes is a dictionary and I am using the key NameIdentifier
        private int GetUserId() => Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        // This method updates the user data (account)
        [Authorize]
        [HttpPut]
        public async Task Update([FromBody] UpdateUserRequest userRequest)
        {
            UserDTO userDTO = _userMapper.ConvertToUserDTO(userRequest);
            userDTO.Id = GetUserId();

            await _userService.Update(userDTO);
        }

        // This method is checking the user login (email and password).
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            // If the login is ok, it will return a User and a bool success = true, If not, will return a string error message
            LoginResult result = await _userService.Login(login.Email, login.Password);

            if (result.Success)
            {
                List<Claim> claim =
                [
                    // It is keeping the user Id in a claim dict with the key NameIdentifier
                    new (ClaimTypes.NameIdentifier, result.User.Id.ToString())
                ];

                var claimsId = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsId));

                return Ok();
            }
            return BadRequest(result.ErrorMessage);
        }

        // This method logout the user
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        // TODO - needs to delete other tables when deleting user
        [Authorize]
        [HttpDelete]
        public async Task Delete()
        {
            //await _userService.Delete(id);
        }
    }
}
