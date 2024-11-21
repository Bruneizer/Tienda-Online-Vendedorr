using Api.Funcionalidades.Productos;
using Biblioteca.Dominio;

namespace Api.Funcionalidades;

public class PublicacionQueryDto
{
    public Guid Id { get; set; }
    public bool Activo { get; set; }
    public ProductoQueryDto Producto { get; set; }

}

public class PublicacionCommandDto
{
    public Guid ProductoId { get; set; }
    public bool Activo { get; set; }
    public Guid IdVendedor { get; set; }
    public string Url { get; set; } 
}



