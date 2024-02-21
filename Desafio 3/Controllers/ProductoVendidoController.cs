using Desafio_3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Desafio_3.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoService productoVendidoService;
        public ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this.productoVendidoService = productoVendidoService;
        }

        [HttpGet(template: "{idUsuario}")]
        public IActionResult ObtenerProductosVendidosPorIdUsuario(int idUsuario)
        {
            return base.Ok(); //no implementado aun
        }

    }
}
