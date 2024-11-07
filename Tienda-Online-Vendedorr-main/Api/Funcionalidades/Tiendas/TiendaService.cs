using Api.Persistencia;
using Biblioteca.Dominio;
using Biblioteca.Validaciones;

namespace Api.Funcionalidades.Tiendas;

public interface ITiendaService
{
    void CreateTienda(TiendaCommandDto TiendaDto);
    void DeleteTienda(Guid idTienda);
    void UpdateTienda(Guid idTienda, TiendaCommandDto TiendaDto);
    List<TiendaQueryDto> GetTienda();
}

public class TiendaService : ITiendaService
{
    private readonly TiendaVendedorDbContext context;

    public TiendaService(TiendaVendedorDbContext context)
    {
        this.context = context;
    }

    public List<TiendaQueryDto> GetTienda()
    {
        return context.Tiendas.Select(tienda => new TiendaQueryDto
        {
            Id = tienda.Id,
            Nombre = tienda.Nombre
        }).ToList();

    }

    public void CreateTienda(TiendaCommandDto TiendaDto)
    {
        Guard.Validaciones(TiendaDto.Nombre, "El nombre de la tienda no puede ser vacia");

        Tienda nuevaTienda = new Tienda()
        {
            Nombre = TiendaDto.Nombre,
        };
        
        context.Tiendas.Add(nuevaTienda);
        context.SaveChanges();
    }

    public void UpdateTienda(Guid idTienda, TiendaCommandDto TiendaDto)
    {
        var tienda = context.Tiendas.SingleOrDefault(x => x.Id == idTienda);
        if (tienda is not null)
        {
            tienda.Nombre = TiendaDto.Nombre;
            context.SaveChanges();
        }
    }
    
    public void DeleteTienda(Guid idTienda)
    {
        var tienda = context.Tiendas.SingleOrDefault(x => x.Id == idTienda);
        if (tienda is not null)
        {
            context.Tiendas.Remove(tienda);
            context.SaveChanges();
        }
    }

}