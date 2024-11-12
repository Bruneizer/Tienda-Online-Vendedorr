using Biblioteca.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Tiendas;

public static class TiendaEndPoint
{
    public static RouteGroupBuilder MapTiendaEndpoint(this RouteGroupBuilder app)
    {
        app.MapGet("/tienda", ([FromServices] ITiendaService tiendaService) =>
        {
            var tiendas = tiendaService.GetTienda();
            return Results.Ok(tiendas);
        });

        app.MapPost("/tienda", ([FromServices] ITiendaService tiendaService, TiendaCommandDto TiendaDto) =>
        {
            tiendaService.CreateTienda(TiendaDto);
            return Results.Ok();
        });

        app.MapPut("/Tienda/{idTienda}", ([FromServices] ITiendaService tiendaService, Guid idTienda, TiendaCommandDto TiendaDto) =>
        {   
            tiendaService.UpdateTienda(idTienda, TiendaDto);
            return Results.Ok();
        });

        app.MapDelete("/Tienda/{idTienda}", ([FromServices] ITiendaService tiendaService, Guid idTienda) =>
        {   
            tiendaService.DeleteTienda(idTienda);
            return Results.Ok();
        });

        return app;

    }
}