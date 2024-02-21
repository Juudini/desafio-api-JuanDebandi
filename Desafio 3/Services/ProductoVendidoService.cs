using Desafio_3.database;
using Desafio_3.models;


namespace Desafio_3.Services
{
    public class ProductoVendidoService
    {
        private CoderContext coderContext;

        public ProductoVendidoService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public List<ProductoVendido> ObtenerProductosVendidosPorProductos(List<Producto> productos)
        {
            return this.coderContext.ProductoVendidos
                .Where(pv => productos.Any(p => p.Id == pv.IdProducto))
                .ToList();
        }




    }
}
