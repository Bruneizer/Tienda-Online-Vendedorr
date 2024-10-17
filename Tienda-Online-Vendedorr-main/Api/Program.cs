using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Api.Persistencia;
using Biblioteca.Dominio;
using Api.Funcionalidades.Categorias;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("TiendaVendedor_bd");

builder.Services.AddDbContext<TiendaVendedorDbContext>(option => option.UseMySql(connectionString, new MySqlServerVersion("8.0.39")));

var options = new DbContextOptionsBuilder<TiendaVendedorDbContext>();

options.UseMySql(connectionString, new MySqlServerVersion("8.0.39"));

var context = new TiendaVendedorDbContext(options.Options);

context.Database.EnsureCreated();

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
app.Run();