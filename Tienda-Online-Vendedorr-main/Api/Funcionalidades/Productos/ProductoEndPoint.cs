// using Api.Funcionalidades.Productos;
// using Biblioteca.Dominio;
// using Microsoft.AspNetCore.Mvc;
// using Api.Funcionalidades;

// namespace Api.Funcionalidades.Productos;

// public static class ProductoEndpoint
// {
//     public static RouteGroupBuilder MapProductoEndpoints(this RouteGroupBuilder app)
//     {
//     app.MapGet("/producto", ([FromServices] IProductoService productoService  ) => {
//         var producto = productoService; GetProducto();
//         return Results.Ok(producto);
//     });
//     app.MapPost("/producto", ([FromServices] IProductoService productoService, ProductoCommanDto productoDto) => {
//         productoService; CreateProducto(productoDto);
//         return Results.Ok();
//     });
//     app.MapPut("/producto/{idproducto}", ([FromServices] IProductoService productoService, Guid idproducto, ProductoCommanDto productoDto) => {
//         productoService; UpdateProducto(Idproducto, productoDto);
//         return Results.Ok();
//     });
//     app.MapDelete("/producto/{idproducto}", ([FromServices] IProductoService productoService, Guid idproducto) => {
//         productoService; DeleteProducto(Idproducto);
//         return Results.Ok();
//     });
        

//         return app;
//     }
// }