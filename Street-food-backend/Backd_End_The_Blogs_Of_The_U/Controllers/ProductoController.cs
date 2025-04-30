using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Services;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.GetAllProductos();
            return Ok(productos);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productoService.CreateProducto(producto);
            return Ok(result);
        }
    }
}