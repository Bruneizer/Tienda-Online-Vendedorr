using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Api.Persistencia;
using Api.Funcionalidades.Categorias;
using Api.Funcionalidades.Usuarios;
using Api.Funcionalidades.Vendedores;
using Api.Funcionalidades.Productos;
using Api.Funcionalidades.Tiendas;
using Api.Funcionalidades.Publicaciones;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("TiendaVendedor_bd");

builder.Services.AddDbContext<TiendaVendedorDbContext>(option => option.UseMySql(connectionString, new MySqlServerVersion("8.0.39")));

builder.Services.AddServiceManager();


var options = new DbContextOptionsBuilder<TiendaVendedorDbContext>();

options.UseMySql(connectionString, new MySqlServerVersion("8.0.39"));

var context = new TiendaVendedorDbContext(options.Options);

context.Database.Migrate();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json";
    });

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGroup("/api")
    .MapCategoriaEndpoint()
    .WithTags("Categoria");

app.MapGroup("/api")
.MapVendedorEndpoints()
.WithTags("Vendedor");

app.MapGroup("/api")
    .MapProductoEndpoints()
    .WithTags("Producto");

app.MapGroup("/api")
    .MapTiendaEndpoint()
    .WithTags("Tienda");

app.MapGroup("/api")
    .MapPublicacionEndpoint()
    .WithTags("Publicacion");


app.Run();