using Biblioteca.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistencia;

public class TiendaVendedorDbContext : DbContext
{
    public TiendaVendedorDbContext(DbContextOptions<TiendaVendedorDbContext> options) : base(options)
    {

    }

    public DbSet<Vendedor> Vendedores {get; set;}
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Producto> Productos {get; set;}
    public DbSet<Tienda> Tiendas {get; set;}
    public DbSet<Publicacion> Publicaciones {get; set;}

}
