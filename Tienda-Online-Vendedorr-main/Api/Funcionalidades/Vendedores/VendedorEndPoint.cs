using Biblioteca.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Vendedores;

public static class VendedorEndPoint
{
    public static RouteGroupBuilder MapvendedorEndpoints  (this RouteGroupBuilder app)
    {
        app.MapGet("/vendedor", ([FromServices] IVendedorService vendedorService) => {
            var vendedor = vendedorService. GetVendedor();
            return Results.Ok(vendedor);

        });

          app.MapPost("/vendedor", ([FromServices] IVendedorService vendedorService, VendedorCommandDto vendedorDto) => {
            vendedorService. CreateVendedor(vendedorDto);
            return Results.Ok();

        });
         app.MapPut("/vendedor/{idvendedor}", ([FromServices] IVendedorService vendedorService, Guid idVendedor, VendedorCommandDto vendedorDto) => {
            vendedorService. UpdateVendedor (idVendedor, vendedorDto);
            return Results.Ok();
        });
            app.MapDelete("/vendedor/{idvendedor}", ([FromServices] IVendedorService vendedorService, Guid idvendedor) => {
            vendedorService. DeleteVendedor (idvendedor);
            return Results.Ok();
         });
        
        return app;
    
    
    }
}