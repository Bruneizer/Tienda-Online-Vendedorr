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
        return context.Publicaciones.Select(publicacion => new PublicacionQueryDto
        {
            Id = publicacion.Id,            
        }).ToList();
    }

    public void CreatePublicacion (PublicacionCommandDto publicacionDto)
    {
        Guard.Validaciones(publicacionDto.producto.Nombre, "El nombre del producto en la publicacion no puede ser vacia");
        Publicacion nuevaPublicacion = new Publicacion()
        {
            Activo = publicacionDto.Activo,
            producto = 

        };
        context.Publicaciones.Add(nuevaPublicacion);
        context.SaveChanges();
    }
    public void UpdatePublicacion(Guid idPublicacion, PublicacionCommandDto publicacionDto)
    {
        var publicacion = context.Publicaciones.SingleOrDefault(x => x.Id == idPublicacion);
        if (publicacion is not null)
        {
            Producto nuevoProducto = new Producto
            {
                Nombre = publicacionDto.producto.Nombre,
                Precio = publicacionDto.producto.Precio,
                CantidadStock = publicacionDto.producto.CantidadStock,
            };

            publicacion.producto = publicacion.producto;
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

}