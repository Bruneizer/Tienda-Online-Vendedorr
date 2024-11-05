using Api.Funcionalidades.Categorias;
using Api.Funcionalidades.Usuarios;
using Api.Funcionalidades.Vendedores;

namespace Api.Funcionalidades.Usuarios;

public static class ServiceManager
{
    public static IServiceCollection AddServiceManager(this IServiceCollection services)
    {
        {
            services.AddScoped<CategoriaService, CategoriaService>();
            services.AddScoped<IVendedorService , VendedorService>();

            return services;
        }
    }
}