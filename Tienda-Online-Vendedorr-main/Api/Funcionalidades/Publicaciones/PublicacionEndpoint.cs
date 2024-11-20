using Microsoft.AspNetCore.Mvc;
using Biblioteca.Dominio;


namespace Api.Funcionalidades.Publicaciones;

public static class PublicacionEndpoint
{
    public static RouteGroupBuilder MapPublicacionEndpoint(this RouteGroupBuilder app)
    {
        app.MapGet("/publicacion", ([FromServices] IPublicacionService publicacionService) =>
        {
            var Publicaciones = publicacionService.GetPublicacion();
            return Results.Ok(Publicaciones);
        });

        app.MapPost("/publicacion", ([FromServices] IPublicacionService publicacionService, PublicacionCommandDto publicacionDto) =>
        {
            publicacionService.CreatePublicacion(publicacionDto);
            return Results.Ok();
        });

        app.MapPut("/Publicacion/{idPublicacion}", ([FromServices] IPublicacionService publicacionService, Guid idPublicacion, PublicacionCommandDto PublicacionDto) =>
        {
            publicacionService.UpdatePublicacion(idPublicacion, PublicacionDto);
            return Results.Ok();
        });

        app.MapPut("/Publicacion/{idPublicacion}/Estado", ([FromServices] IPublicacionService publicacionService, Guid idPublicacion, bool estado) =>
        {
                // Cambiar el estado de la publicación
                publicacionService.CambiarEstadoPublicacion(idPublicacion, estado);
                return Results.Ok();
                
        });


        app.MapDelete("/Publicacion/{idPublicacion}", ([FromServices] IPublicacionService publicacionService, Guid idPublicacion) =>
        {
            publicacionService.DeletePublicacion(idPublicacion);
            return Results.Ok();
        });

        return app;

    }
}