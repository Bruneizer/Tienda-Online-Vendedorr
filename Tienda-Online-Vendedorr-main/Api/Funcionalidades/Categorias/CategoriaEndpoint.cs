using Api.Persistencia;
using Biblioteca.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Categorias;

public static class CategoriaEndpoint
{
    public static RouteGroupBuilder MapCategoriaEndpoint(this RouteGroupBuilder app)
    {
        app.MapGet("/Categorias",([FromServices] CategoriaService categoriaService) =>
        {
            var Categorias = categoriaService.GetCategoria();
            return Results.Ok(Categorias);
        });

        app.MapPost("/Categorias", (TiendaVendedorDbContext context, [FromBody] CategoriaCommandDto  categoria) =>
        {
            Categoria nuevaCategoria = new Categoria() { Nombre = categoria.Nombre };
            context.Categorias.Add(nuevaCategoria);
            context.SaveChanges();
            return Results.Ok();
        });
        return app;

    }
}