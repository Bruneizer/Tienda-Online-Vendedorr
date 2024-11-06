// using Api.Persistencia;
// using Biblioteca.Dominio;
// using Biblioteca.Validaciones;

// namespace Api.Funcionalidades.Productos;


// public interface IVendedorService
// {
//     List<ProductoQueryDto> GetProducto();
//     void CreateProducto(ProductoCommandDto productoDto);
//     void UpdateProducto(Guid IdProducto, ProductoCommandDto vendedorDto);
//     void DeleteProducto(Guid IdProducto);
// }
// public class ProductpService : IProductoService
// {
//     private readonly TiendaVendedorDbContext context;

//     public ProductoService(TiendaVendedorDbContext context)
//     {
//         this.context = context;
//     }
//     public void CreateProducto(ProductoCommanDto productoDto)
//     {
//         Guard.Validaciones(productoDto.Nombre, "El nombre del producto no puede ser vacio");
//         var producto = new Vendedor
//         {
//             Nombre = vendedorDto.Nombre,
//             Apellido = vendedorDto.Apellido,
//             Email = vendedorDto.Email,
//             CUIT = vendedorDto.CUIT,
//             NombreUsuario = vendedorDto.NombreUsuario,
//             Contraseña = vendedorDto.Contraseña
//         };

//         context.Vendedores.Add(vendedor);
//         context.SaveChanges();
//     }

//     public void DeleteVendedor(Guid IdVendedor)
//     {
//          var vendedor = context.Vendedores.SingleOrDefault(x => x.Id == IdVendedor);
//         if (vendedor is not null)
//         {
//             context.Vendedores.Remove(vendedor);
//             context.SaveChanges();
//         }
//     }

//     public List<VendedorQueryDto> GetVendedor()
//     {
//         return context.Vendedores.Select(vendedores => new VendedorQueryDto
//         {
//             Id = vendedores.Id,
//             Nombre = vendedores.Nombre,
//             Apellido = vendedores.Apellido,
//             Email = vendedores.Email,
//             CUIT = vendedores.CUIT,
//             NombreUsuario = vendedores.NombreUsuario,
//             Contraseña = vendedores.Contraseña,
//         }).ToList();
//     }

//     public void UpdateVendedor(Guid IdVendedor, VendedorCommandDto vendedorDto)
//     {
//          var vendedor = context.Vendedores.SingleOrDefault(x => x.Id == IdVendedor);
//         if (vendedor is not null)
//         {
//             vendedor.Nombre = vendedorDto.Nombre;
//             context.SaveChanges();
//         }
//     }
// }