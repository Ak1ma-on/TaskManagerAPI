using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserRequest userRequest)
        {
            try
            {
                await _userService.RegisterAsync(userRequest.Username, userRequest.Password);
            }
            catch (ArgumentException)
            {
                return Conflict();
            }          
            return Created();     
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserRequest userRequest)
        {
            string? token;
            try
            {
                token = await _userService.LoginAsync(userRequest.Username, userRequest.Password);
                if (token == null) return Unauthorized();                          
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            return Ok(token);
        }
    }
}