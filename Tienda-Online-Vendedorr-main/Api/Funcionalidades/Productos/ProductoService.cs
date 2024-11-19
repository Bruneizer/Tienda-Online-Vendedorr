using Api.Funcionalidades.Categorias;
using Api.Funcionalidades.Productos;
using Api.Persistencia;
using Biblioteca.Dominio;
using Biblioteca.Validaciones;

namespace Api.Funcionalidades.Productos
{
    public interface IProductoService
    {
        List<ProductoQueryDto> GetProducto();
        void CreateProducto(ProductoCommanDto productoDto);
        void UpdateProducto(Guid IdProducto, ProductoCommanDto productoDto);
        void DeleteProducto(Guid IdProducto);
    }

    public class ProductoService : IProductoService
    {
        private readonly TiendaVendedorDbContext context;
        public ProductoService(TiendaVendedorDbContext context)
        {
            this.context = context;
        }

        public void CreateProducto(ProductoCommanDto productoDto)
        {
            Guard.Validaciones(productoDto.Nombre, "El nombre del producto no puede ser vacío");
            Guard.Validaciones(productoDto.Precio, "El precio del producto no puede ser vacío");
            Guard.Validaciones(productoDto.CantidadStock, "El stock del producto no puede ser vacío");


            var categoria = context.Categorias.SingleOrDefault(c => c.Id == productoDto.IdCategoria);
            
            if (categoria == null)
            {
                throw new ArgumentException("La categoría especificada no existe");
            }

            var producto = new Producto
            {
                Nombre = productoDto.Nombre,
                Precio = productoDto.Precio,
                CantidadStock = productoDto.CantidadStock,
                Descripcion = productoDto.Descripcion,
                categoria = categoria 
            };

            context.Productos.Add(producto);
            context.SaveChanges();
        }

        public void DeleteProducto(Guid IdProducto)
        {
            var producto = context.Productos.SingleOrDefault(x => x.Id == IdProducto);
            if (producto is not null)
            {
                context.Productos.Remove(producto);
                context.SaveChanges();
            }
        }

        public List<ProductoQueryDto> GetProducto()
        {
            return context.Productos.Select(productos => new ProductoQueryDto
            {
                Id = productos.Id,
                Nombre = productos.Nombre,
                Precio = productos.Precio,
                CantidadStock = productos.CantidadStock,
                Descripcion = productos.Descripcion,
                Categoria = productos.categoria.Nombre,
            }).ToList();
        }

        public void UpdateProducto(Guid IdProducto, ProductoCommanDto productoDto)
        {
            var producto = context.Productos.SingleOrDefault(x => x.Id == IdProducto);
            if (producto is not null)
            {
                producto.Nombre = productoDto.Nombre;
                producto.Precio = productoDto.Precio;
                producto.CantidadStock = productoDto.CantidadStock;
                producto.Descripcion = productoDto.Descripcion;

                var categoria = context.Categorias.SingleOrDefault(c => c.Id == productoDto.IdCategoria);
                if (categoria != null)
                {
                    producto.categoria = categoria;
                }

                context.SaveChanges();
            }
        }
    }
}
