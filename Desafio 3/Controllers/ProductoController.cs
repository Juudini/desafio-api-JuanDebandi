using Desafio_3.DTOs;
using Desafio_3.service;
using Desafio_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_3.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]

    public class ProductoController : Controller
    {
        private ProductoService productoService;
        public ProductoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet(template: "{idUsuario}")]
        public IActionResult ObtenerProductosPorUsuario(int idUsuario)
        {
            var productos = this.productoService.ObtenerProductosPorUsuario(idUsuario);
            if (productos == null)
            {
                return NotFound($"No se encontraron productos para el usuario con IdUsuario: {idUsuario}."); // Si no se encontraron productos, devuelve un código 404 Not Found
            }
            return Ok(new { mensaje = $"Se encontraron los siguientes productos asociados al idUsuario: {idUsuario}", productos }); // Devuelve los productos encontrados con un código 200 OK
        }

        [HttpPost]
        public IActionResult AgregarUnNuevoProducto([FromBody] ProductoDTO producto)
        {

            if (this.productoService.AgregarUnProducto(producto))
            {

                return base.Ok(new { mensaje = "Producto agregado", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego un producto" });
            }
        }

        [HttpPut]
        public IActionResult ActualizarProductoPorId([FromQuery]int id, [FromBody]ProductoDTO productoDTO)
        {
            if (id > 0)
            {
                if (this.productoService.ActualizarProductoPorId(id, productoDTO))
                {
                    return base.Ok(new { mensaje = "Producto Actualizado", status = 200, productoDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpDelete("{idProducto}")]
        public IActionResult BorrarProducto(int idProducto)
        {
            if (idProducto > 0)
            {
                if (this.productoService.BorrarProductoPorId(idProducto))
                {
                    return base.Ok(new { mensaje = "Producto borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }



    }
}
