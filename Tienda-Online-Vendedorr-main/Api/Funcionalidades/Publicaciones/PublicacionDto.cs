using Api.Funcionalidades.Productos;
using Biblioteca.Dominio;

namespace Api.Funcionalidades;

public class PublicacionQueryDto
{

    public Guid Id { get; set; }
}

public class PublicacionCommandDto
{
    public required ProductoCommanDto producto { get; set; }
    public bool Activo { get; set; }


}
