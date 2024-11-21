using Api.Funcionalidades.Categorias;
using Api.Funcionalidades.Usuarios;
using Api.Funcionalidades.Vendedores;
using Api.Funcionalidades.Productos;
using Biblioteca.Dominio;
using Api.Funcionalidades.Tiendas;
using Api.Funcionalidades.Publicaciones;

namespace Api.Funcionalidades.Usuarios;

public static class ServiceManager
{
    public static IServiceCollection AddServiceManager(this IServiceCollection services)
    {
        {
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IVendedorService , VendedorService>();
            services.AddScoped<IProductoService , ProductoService>();
            services.AddScoped<ITiendaService , TiendaService>();
            services.AddScoped<IPublicacionService , PublicacionService>();

            return services;
        }
    }
}