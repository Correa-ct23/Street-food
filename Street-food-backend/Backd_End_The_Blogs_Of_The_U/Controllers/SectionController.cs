using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Services;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly SectionsService _sectionsService;

        public SectionController(SectionsService sectionsService) { 
            _sectionsService = sectionsService;
        }

        [HttpGet("get-all-sections")]
        public async Task<IActionResult> GetAllSections()
        {
            List<Sections> sections = await _sectionsService.GetAllSections();
            return Ok(sections);
        }

        [HttpPost("create-sections")]
        public async Task<IActionResult> CreateSection([FromBody] Sections sections)
        {
            if (string.IsNullOrWhiteSpace(sections.SectionName) || string.IsNullOrWhiteSpace(sections.Description))
                return BadRequest("Faltan campos requeridos o valores inválidos.");

            try
            {
                bool isInserted = await _sectionsService.AddSection(sections);
                return Ok(isInserted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}
