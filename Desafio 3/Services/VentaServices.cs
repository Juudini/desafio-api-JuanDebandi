using Desafio_3.database;
using Desafio_3.DTOs;
using Desafio_3.Mapper;
using Desafio_3.models;

namespace Desafio_3.Services
{
    public class VentaServices
    {
        private CoderContext coderContext;

        public VentaServices(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public List<Ventum> ObtenerVentasPorIdUsuario(int idUsuario)
        {
            return this.coderContext.Venta.Where(v => v.IdUsuario == idUsuario).ToList();
        }

        public bool AgregarUnaVenta(VentaDTO dto)
        {
            Ventum v = VentaMapper.MapearAVenta(dto);

            this.coderContext.Venta.Add(v);
            this.coderContext.SaveChanges();
            return true;
        }

    }
}
