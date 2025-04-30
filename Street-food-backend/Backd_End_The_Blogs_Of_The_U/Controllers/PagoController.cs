using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Services;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly PagoService _pagoService;

        public PagoController(PagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet("metodos-pago")]
        public async Task<IActionResult> GetMetodosPago()
        {
            var metodos = await _pagoService.GetAllMetodosPago();
            return Ok(metodos);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarPago([FromBody] Pago pago)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _pagoService.CreatePago(pago);
            return Ok(result);
        }
    }
}