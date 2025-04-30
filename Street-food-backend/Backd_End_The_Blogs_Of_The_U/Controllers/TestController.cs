using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Blogs_Of_The_U.Domain;
using The_Blogs_Of_The_U.Domain.Services;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class TestController: ControllerBase
    {
        [HttpGet("test-connections")]
        public IActionResult TestConnections() {
            return Ok($"Todo melo");  
        }

    }
}
