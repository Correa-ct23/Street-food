using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Services;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class RolesController:ControllerBase
    {
        private readonly RolesService _rolesService;

        public RolesController(RolesService rolesService)
        {
            _rolesService = rolesService;
        }


        [HttpGet("get-all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            List<Roles> roles = await _rolesService.GetAllRoles();
            return Ok(roles);
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] Roles role)
        {
            return Ok(await _rolesService.CreateRole(role));

        }

    }
}
