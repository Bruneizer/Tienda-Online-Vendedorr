using Api.Funcionalidades.Categorias;
using Api.Funcionalidades.Productos;
using Api.Persistencia;
using Biblioteca.Dominio;
using Biblioteca.Validaciones;

namespace Api.Funcionalidades.Publicaciones;

public interface IPublicacionService
{
    void CreatePublicacion (PublicacionCommandDto publicacionDto);
    void UpdatePublicacion(Guid idPublicacion, PublicacionCommandDto publicacionDto);
    void DeletePublicacion(Guid idPublicacion);
    public void CambiarEstadoPublicacion(Guid idPublicacion, bool estado);
    List<PublicacionQueryDto> GetPublicacion();
}

public class PublicacionService : IPublicacionService
{
    private readonly TiendaVendedorDbContext context;

    public PublicacionService(TiendaVendedorDbContext context)
    {
        this.context = context;
    }

    public List<PublicacionQueryDto> GetPublicacion()
    {
    return context.Publicaciones
        .Select(publicacion => new PublicacionQueryDto
        {
            Id = publicacion.Id,
            Activo = publicacion.Activo,
            Producto = new ProductoQueryDto
            {
                Id = publicacion.producto.Id,
                Nombre = publicacion.producto.Nombre,
                Precio = publicacion.producto.Precio,
                CantidadStock = publicacion.producto.CantidadStock,
                Descripcion = publicacion.producto.Descripcion,
                Categoria = publicacion.producto.categoria.Nombre
            },
            VendedorId = publicacion.Vendedor.Id // Recuperar el ID del vendedor
        }).ToList();
    }

public void CreatePublicacion(PublicacionCommandDto publicacionDto)
{
    var producto = context.Productos.SingleOrDefault(p => p.Id == publicacionDto.ProductoId);
    if (producto == null)
    {
        throw new ArgumentException("El producto especificado no existe");
    }

    var vendedor = context.Vendedores.SingleOrDefault(v => v.Id == publicacionDto.VendedorId);
    if (vendedor == null)
    {
        throw new ArgumentException("El vendedor especificado no existe");
    }

    Publicacion nuevaPublicacion = new Publicacion()
    {
        Activo = publicacionDto.Activo,
        producto = producto,
        Vendedor = vendedor 
    };
    
    context.Publicaciones.Add(nuevaPublicacion);
    context.SaveChanges();
}


public void UpdatePublicacion(Guid idPublicacion, PublicacionCommandDto publicacionDto)
{
    var publicacion = context.Publicaciones.SingleOrDefault(x => x.Id == idPublicacion);
    if (publicacion is not null)
    {
        var producto = context.Productos.SingleOrDefault(p => p.Id == publicacionDto.ProductoId);
        if (producto == null)
        {
            throw new ArgumentException("El producto especificado no existe");
        }

        publicacion.Activo = publicacionDto.Activo;
        publicacion.producto = producto;
        context.SaveChanges();
    }
}

    public void DeletePublicacion(Guid idPublicacion)
    {
        var publicacion = context.Publicaciones.SingleOrDefault(x => x.Id == idPublicacion);
        if (publicacion is not null)
        {
            context.Publicaciones.Remove(publicacion);
            context.SaveChanges();
        }
    }

    public void CambiarEstadoPublicacion(Guid idPublicacion, bool estado)
{
    // Buscar la publicación por ID 
    var publicacion = context.Publicaciones
        .SingleOrDefault(x => x.Id == idPublicacion);

    if (publicacion is null)
    {
        throw new ArgumentException("La publicación no existe o no pertenece al vendedor especificado.");
    }

    // Cambiar el estado de la publicación
    publicacion.Activo = estado;

    // Guardar los cambios en la base de datos
    context.SaveChanges();
}


}