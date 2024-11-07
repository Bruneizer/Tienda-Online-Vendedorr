using Biblioteca.Dominio;

namespace Api.Funcionalidades.Tiendas;

public class TiendaEndPoint
{
    public static RouteGroupBuilder MapTiendaEndpoint(this RouteGroupBuilder app)
    {
        app.MapGet("/tienda", ([FromServices] TiendaService tiendaService) =>
        {
            var tiendas = TiendaService.GetTienda();
            return Results.Ok(tiendas);
        });

        app.MapPost("/tienda", ([FromServices] TiendaService tiendaService, TiendaCommandDto TiendaDto) =>
        {
            TiendaService.CreateTienda(TiendaDto);
            return Results.Ok();
        });

        app.MapPut("/Tienda/{idTienda}", ([FromServices] TiendaService tiendaService, Guid idTienda, TiendaCommandDto TiendaDto) =>
        {   
            TiendaService.UpdateTienda(idTienda, TiendaDto);
            return Results.Ok();
        });

        app.MapDelete("/Tienda/{idTienda}", ([FromServices] TiendaService tiendaService, Guid idTienda) =>
        {   
            TiendaService.DeleteTienda(idTienda);
            return Results.Ok();
        });

        return app;

    }
}