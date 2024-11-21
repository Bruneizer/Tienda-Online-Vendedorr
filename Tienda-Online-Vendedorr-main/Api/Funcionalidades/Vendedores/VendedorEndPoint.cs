using Biblioteca.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Vendedores;

public static class VendedorEndPoint
{
    public static RouteGroupBuilder MapVendedorEndpoints(this RouteGroupBuilder app)
    {
        app.MapGet("/vendedor", ([FromServices] IVendedorService vendedorService) =>
        {
            try
            {
                var vendedores = vendedorService.GetVendedor();
                return Results.Ok(vendedores);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error al obtener los vendedores: {ex.Message}");
            }
        });

        app.MapPost("/vendedor", ([FromServices] IVendedorService vendedorService, VendedorCommandDto vendedorDto) =>
        {
            try
            {
                vendedorService.CreateVendedor(vendedorDto);
                return Results.Created($"/vendedor/{vendedorDto.NombreUsuario}", null);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error al crear el vendedor: {ex.Message}");
            }
        });

        app.MapPut("/vendedor/{idvendedor}", ([FromServices] IVendedorService vendedorService, Guid idVendedor, VendedorCommandDto vendedorDto) =>
        {
            try
            {
                vendedorService.UpdateVendedor(idVendedor, vendedorDto);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error al actualizar el vendedor: {ex.Message}");
            }
        });

        app.MapDelete("/vendedor/{idvendedor}", ([FromServices] IVendedorService vendedorService, Guid idVendedor) =>
        {
            try
            {
                vendedorService.DeleteVendedor(idVendedor);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error al eliminar el vendedor: {ex.Message}");
            }
        });

        return app;
    }
}
