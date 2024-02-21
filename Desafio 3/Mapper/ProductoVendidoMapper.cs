using Desafio_3.DTOs;
using Desafio_3.models;

namespace Desafio_3.Mapper
{
    public static class ProductoVendidoMapper
    {
        public static ProductoVendido MapearAProducto(ProductoVendidoDTO dto)
        {
            ProductoVendido productoVendido = new ProductoVendido();
            
            productoVendido.Id = dto.Id;
            productoVendido.Stock = dto.Stock;
            productoVendido.IdProducto = dto.IdProducto;
            productoVendido.IdVenta = dto.IdVenta;

            return productoVendido;
        }

        public static ProductoVendidoDTO MapearADTO(ProductoVendido productoVendido)
        {
            ProductoVendidoDTO dto = new ProductoVendidoDTO();

            dto.Id = productoVendido.Id;
            dto.Stock = productoVendido.Stock;
            dto.IdProducto = productoVendido.IdProducto;
            dto.IdVenta = productoVendido.IdVenta;

            return dto;

        }
    }
}
