
// using Biblioteca.Dominio;
// using Microsoft.AspNetCore.Mvc;

// namespace Api.Funcionalidades.Productos;
// public static class ProductoEndPoint{
//     public static RouteGroupBuilder MapproductoEndpoints(this RouteGroupBuilder app)
//     {    
//         app.MapGet("/producto", ([FromServices] IProductoService productoService) =>{
//             var producto = productoService. GetProducto();
//             return Results.Ok(producto)   ;
            
//         });
//         app.MapPost("/producto", ([FromServices] IProductoService productoService, ProductoCommanDto productoDto) => {
//             productoService. CreateProducto(productoDto);
//             return Results.Ok();

//         });
//          app.MapPut("/producto/{idproducto}", ([FromServices] IProductoService productoService, Guid idproducto, ProductoCommanDto productoDto) => {
//             productoService. UpdateProducto (idProducto, productoDtoDto);
//             return Results.Ok();
//         });
//         app.MapDelete("/producto/{idproducto}", ([FromServices] IProductoService productoService, Guid idproducto) => {
//             productoService. DeleteProducto (idproducto);
//             return Results.Ok();
//          });

//         return app;
//     }
// }

