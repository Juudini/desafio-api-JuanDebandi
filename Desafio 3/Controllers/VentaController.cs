using Desafio_3.DTOs;
using Desafio_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_3.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]

    public class VentaController : Controller
    {
        private VentaServices ventaService;
        public VentaController(VentaServices ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpGet(template: "{idUsuario}")]
        public IActionResult ObtenerVentasPorIdUsuario(int idUsuario)
        {
            var ventas = this.ventaService.ObtenerVentasPorIdUsuario(idUsuario);
            if (ventas == null || ventas.Count == 0)
            {
                return NotFound();
            }
            return Ok(ventas);
        }

        [HttpPost]
        public IActionResult AgregarUnaNuevaVenta([FromBody] VentaDTO venta)
        {

            if (this.ventaService.AgregarUnaVenta(venta))
            {

                return base.Ok(new { mensaje = "Venta agregada", venta });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego la venta" });
            }
        }
    }
}
