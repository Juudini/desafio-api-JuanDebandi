using Desafio_3.database;
using Desafio_3.DTOs;
using Desafio_3.Mapper;
using Desafio_3.models;

namespace Desafio_3.Services
{
    public class ProductoService
    {
        private CoderContext coderContext;

        public ProductoService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public bool AgregarUnProducto(ProductoDTO dto)
        {
            Producto p = ProductoMapper.MapearAProducto(dto);

            this.coderContext.Productos.Add(p);
            this.coderContext.SaveChanges();
            return true;
        }

        public List<Producto> ObtenerProductosPorUsuario(int idUsuario)
        {
            var productos = this.coderContext.Productos.Where(p => p.IdUsuario == idUsuario).ToList();
            if (productos.Count == 0)
            {
                return null;
            }
            return productos;
        }

        public bool ActualizarProductoPorId(int id, ProductoDTO productoDTO)
        {
            Producto? producto = this.coderContext.Productos.Where(p => p.Id == id).FirstOrDefault();

            if (producto is not null)
            {
                producto.PrecioVenta = productoDTO.PrecioVenta;
                producto.Stock = productoDTO.Stock;
                producto.Descripciones = productoDTO.Descripciones;
                producto.IdUsuario = productoDTO.IdUsuario;
                producto.Costo = productoDTO.Costo;

                this.coderContext.Productos.Update(producto);
                this.coderContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool BorrarProductoPorId(int id)
        {
            Producto? producto = this.coderContext.Productos.Where(p => p.Id == id).FirstOrDefault();

            if (producto is not null)
            {
                this.coderContext.Remove(producto);
                this.coderContext.SaveChanges();
                return true;
            }

            return false;
        }




    }
}

