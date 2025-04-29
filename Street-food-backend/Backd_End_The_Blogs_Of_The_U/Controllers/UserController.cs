using Microsoft.AspNetCore.Mvc;
using static The_Blogs_Of_The_U.Domain.Models.UserResponse;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Services;
using The_Blogs_Of_The_U.Infrastructure.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly string _secretKey;
        private readonly AutenticacionService _autenticacionService;

        public UserController(IConfiguration config, UserService userService, AutenticacionService autenticacionService )
        {
            _secretKey = config.GetSection("JwtSettings").GetSection("SecretKey").ToString();
            _userService = userService;
            _autenticacionService = autenticacionService;
        }

        [HttpGet("user-access-validation")]
        [AllowAnonymous]
        public async Task<IActionResult> UserAccessValidation([FromQuery] string email, [FromQuery] string password)
        {

            UserAcces userAcces = new UserAcces { Email = email, Password = password };
            ResponseLogin user = await _userService.UserAccessValidation(userAcces);
            if (user != null && user.UserAcces != null && user.User != null) {

                string token = await _autenticacionService.getAccesToken(_secretKey, email);
                return StatusCode(StatusCodes.Status200OK, new {Token = token, AccessUser= user });
            }
            return StatusCode(StatusCodes.Status401Unauthorized, new { Toke = " ", AccessUser = (object?)null });
        }

        [HttpPost("password-recovery")]
        public async Task<IActionResult> PasswordRecovery([FromQuery] string email, [FromQuery] string password)
        {
            bool changes = await _userService.PasswordRecovery(email, password);
            return Ok(changes);

        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserAcces.Email) ||
                string.IsNullOrWhiteSpace(request.UserAcces.Password) ||
                string.IsNullOrWhiteSpace(request.users.UserName) ||
                string.IsNullOrWhiteSpace(request.users.Document) ||
                request.users.RolId <= 0)
            {
                return BadRequest("Faltan campos requeridos o valores inválidos.");
            }

            try
            {
 
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("get-user-rol")]
        public async Task<IActionResult> GetRolUser([FromQuery] string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest("El nombre de usuario no puede estar vacío.");
            }

            Roles roles = await _userService.GetuserRole(userEmail);

            if (roles == null)
            {
                return NotFound($"El usurio {userEmail} no tiene rol definido.");
            }

            return Ok(roles);
        }

        [HttpGet("get-all-users")]
        public async Task<ActionResult> GetAllUsers() {
            return StatusCode(StatusCodes.Status200OK, await _userService.GetAllUsers());
        }

        [HttpGet("get-my-clients")]
        public async Task<ActionResult> GetMyClients()
        {
            return StatusCode(StatusCodes.Status200OK, await _userService.GetAllUsers());
        }

            


    }
}
