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

app.MapPut("/publicacion/{idPublicacion}/activo", async (Guid idPublicacion, bool activo, Guid idVendedor, [FromServices] IPublicacionService publicacionService) =>
{
    try
    {
        // Llamar al método para actualizar solo el estado 'Activo' de la publicación
        publicacionService.UpdateActivoPublicacion(idPublicacion, activo, idVendedor);

        return Results.Ok("El estado de la publicación se ha actualizado correctamente.");
    }
    catch (UnauthorizedAccessException ex)
    {
        // Devolver un 403 Forbidden con el mensaje detallado
        return Results.Problem(
            detail: ex.Message,
            statusCode: 403,
            title: "Acceso Denegado"
        );
    }
    catch (ArgumentException ex)
    {
        // Devolver un 400 BadRequest con el mensaje detallado
        return Results.Problem(
            detail: ex.Message,
            statusCode: 400,
            title: "Solicitud Incorrecta"
        );
    }
});







        app.MapPut("/Publicacion/{idPublicacion}", ([FromServices] IPublicacionService publicacionService, Guid idPublicacion, PublicacionCommandDto PublicacionDto) =>
        {
            publicacionService.UpdatePublicacion(idPublicacion, PublicacionDto);
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