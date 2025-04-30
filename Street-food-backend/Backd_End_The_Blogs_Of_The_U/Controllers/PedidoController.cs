using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Services;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllPedidos();
            return Ok(pedidos);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pedidoId = await _pedidoService.CreatePedido(pedido);
            return Ok(new { PedidoId = pedidoId });
        }

        [HttpPost("add-detalle")]
        public async Task<IActionResult> AddDetalle([FromBody] DetallePedido detalle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _pedidoService.AddDetallePedido(detalle);
            return Ok(result);
        }
    }
}