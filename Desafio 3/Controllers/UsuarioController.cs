using Desafio_3.database;
using Desafio_3.DTOs;
using Desafio_3.models;
using Desafio_3.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Desafio_3.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]

       
    public class UsuarioController : Controller
    {
        private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }


        [HttpGet(template:"listado")]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return this.usuarioService.ObtenerTodosLosUsuarios();
        }

        [HttpGet(template: "{nombreUsuario}")]
        public IActionResult ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            var usuario = this.usuarioService.ObtenerUsuarioPorNombreUsuario(nombreUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet(template: "{nombreUsuario}/{password}")]
        public IActionResult ObtenerUsuarioPorNombreyPassword(string nombreUsuario, string password)
        {
            var usuario = this.usuarioService.ObtenerUsuarioPorNombreyPassword(nombreUsuario, password);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult AgregarUnNuevoUsuario([FromBody] UsuarioDTO usuario)
        {
            if (this.usuarioService.AgregarUnUsuario(usuario))
            {
                return base.Ok(usuario);
            }
            else
            {
                return base.Conflict(new {mensaje = "No se agrego el usuario"});
            }            
        }

        [HttpPut]
        public IActionResult ActualizarUsuarioPorId([FromQuery]int id, [FromBody]UsuarioDTO usuarioDTO)
        {
            if (id > 0)
            {
                if (this.usuarioService.ActualizarUsuarioPorId(id, usuarioDTO))
                {
                    return base.Ok(new { mensaje = "Usuario Actualizado", status = 200, usuarioDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar el usuario" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

    }
}
