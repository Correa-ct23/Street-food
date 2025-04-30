//Controller de autenticación. No es necesario para la primer entrega por lo ual se inhabilita.



using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using The_Blogs_Of_The_U.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class AutenticacionController: ControllerBase
    {
        private readonly string _secretKey;
        private readonly AutenticacionService _autenticacionService;
        public AutenticacionController(IConfiguration config, AutenticacionService autenticacionService)
        {
            _secretKey = config.GetSection("JwtSettings").GetSection("SecretKey").ToString();
            _autenticacionService = autenticacionService;
        }

        [HttpGet]
        [Route("get-token")]
        public  async Task<IActionResult> getAccesToken([FromQuery] string access) {
            string parameter= await _autenticacionService.validationToken(access);
            if (!string.IsNullOrEmpty(parameter))
            {
                string token = await _autenticacionService.getAccesToken(_secretKey, access);
                return StatusCode(StatusCodes.Status200OK, new { Token = token });
            }
            else {
                return StatusCode(StatusCodes.Status401Unauthorized, new { Token = "" });

            }

        }
    }
}
