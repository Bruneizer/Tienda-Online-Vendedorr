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

    public void CambiarEstadoPublicacion(Guid idPublicacion, bool nuevoEstado);

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
                Categoria = publicacion.producto.categoria.Nombre,
            },
            Url = publicacion.Url,
            idVendedor = publicacion.Vendedor.Id
        }).ToList();
    }

public void CreatePublicacion(PublicacionCommandDto publicacionDto)
{
    var producto = context.Productos.SingleOrDefault(p => p.Id == publicacionDto.ProductoId);
    if (producto == null)
    {
        throw new ArgumentException("El producto especificado no existe");
    }

    var vendedor = context.Vendedores.SingleOrDefault(v => v.Id == publicacionDto.IdVendedor);
    if (vendedor == null)
    {
        throw new ArgumentException("El vendedor especificado no existe");
    }

    // Si no se proporciona una URL, generar una automáticamente
    string url = publicacionDto.Url ?? $"https://miapp.com/publicaciones/{Guid.NewGuid()}";

    Publicacion nuevaPublicacion = new Publicacion()
    {
        Activo = publicacionDto.Activo,
        producto = producto,
        Vendedor = vendedor,
        Url = url // Asignar la URL
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

public void CambiarEstadoPublicacion(Guid idPublicacion, bool nuevoEstado)
{
    // Buscar la publicación por ID
    var publicacion = context.Publicaciones.SingleOrDefault(x => x.Id == idPublicacion);

    // Verificar si la publicación existe
    if (publicacion == null)
    {
        throw new ArgumentException("La publicación especificada no existe.");
    }

    // Actualizar el estado de la publicación
    publicacion.Activo = nuevoEstado;

    // Guardar cambios en la base de datos
    context.SaveChanges();
}


}