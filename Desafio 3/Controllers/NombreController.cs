using Microsoft.AspNetCore.Mvc;

namespace Desafio_3.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class NombreController : Controller
    {
        [HttpGet(template:"obtenerNombre")]
        public string ObtenerNombre()
        {
            return "Lucas De Maio";
        }
    }
}
