namespace Api.Funcionalidades.Vendedores;

public class VendedorQueryDto : VendedorCommandDto
{
    public Guid Id { get; set; }
}

public class VendedorCommandDto
{
    public required string Nombre {get;set;}
    public required string Apellido {get;set;}
    public required string Email {get;set;}
    public required string CUIT {get;set;}
    public required string NombreUsuario {get;set;}
    public required string Contraseña {get;set;}
}