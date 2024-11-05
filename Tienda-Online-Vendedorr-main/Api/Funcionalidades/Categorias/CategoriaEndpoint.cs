using Microsoft.AspNetCore.Mvc;
using Api.Persistencia;

namespace Api.Funcionalidades.Categorias;

public static class CategoriaEndpoint
{
    public static RouteGroupBuilder MapCategoriaEndpoint(this RouteGroupBuilder app)
    {
        app.MapGet("/categoria", ([FromServices] CategoriaService categoriaService) =>
        {
            var Categorias = categoriaService.GetCategoria();
            return Results.Ok(Categorias);
        });

        app.MapPost("/categoria", ([FromServices] CategoriaService categoriaService, CategoriaCommandDto categoriaDto) =>
        {
            categoriaService.CreateCategoria(categoriaDto);
            return Results.Ok();
        });

        app.MapPut("/Categoria/{idCategoria}", ([FromServices] CategoriaService categoriaService, Guid idCategoria, CategoriaCommandDto CategoriaDto) =>
        {   
            categoriaService.UpdateCategoria(idCategoria, CategoriaDto);
            return Results.Ok();
        });

        app.MapDelete("/Categoria/{idCategoria}", ([FromServices] CategoriaService categoriaService, Guid idCategoria) =>
        {   
            categoriaService.DeleteCategoria(idCategoria);
            return Results.Ok();
        });

        return app;

    }
}