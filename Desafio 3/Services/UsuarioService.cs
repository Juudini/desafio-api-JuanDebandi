using Desafio_3.database;
using Desafio_3.DTOs;
using Desafio_3.Mapper;
using Desafio_3.models;
using Desafio_3.service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace Desafio_3.service
{
    public class UsuarioService
    {
        private CoderContext coderContext;

        public UsuarioService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return this.coderContext.Usuarios.ToList();
        }

        public Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return this.coderContext.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }


        public Usuario ObtenerUsuarioPorNombreyPassword(string nombreUsuario, string password)
        {
            return this.coderContext.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == password);
        }

        public bool AgregarUnUsuario(UsuarioDTO dto)
        {
            Usuario u = UsuarioMapper.MapearAUsuario(dto);
            

            this.coderContext.Usuarios.Add(u);
            this.coderContext.SaveChanges();
            return true;
        }

        public bool ActualizarUsuarioPorId(int id, UsuarioDTO usuarioDTO)
        {
            Usuario? usuario = this.coderContext.Usuarios.Where(u => u.Id == id).FirstOrDefault();

            if (usuario is not null)
            {
                usuario.Nombre = usuarioDTO.Nombre;
                usuario.Apellido = usuarioDTO.Apellido;
                usuario.NombreUsuario = usuarioDTO.NombreUsuario;
                usuario.Contraseña = usuarioDTO.Contraseña;
                usuario.Mail = usuarioDTO.Mail;

                this.coderContext.Usuarios.Update(usuario);
                this.coderContext.SaveChanges();
                return true;
            }


            return false;
        }

        public List<Producto> ObtenerProductosPorIdUsuario(int idUsuario)
        {
            return this.coderContext.Productos
                .Where(p => p.IdUsuario == idUsuario)
                .ToList();
        }

    }
}
