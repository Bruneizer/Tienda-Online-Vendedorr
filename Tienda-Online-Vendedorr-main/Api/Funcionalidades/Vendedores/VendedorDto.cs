namespace Api.Funcionalidades.Vendedores;

public class VendedorQueryDto : VendedorCommandDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CUIT { get; set; } = string.Empty;
    public string NombreUsuario { get; set; } = string.Empty;
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