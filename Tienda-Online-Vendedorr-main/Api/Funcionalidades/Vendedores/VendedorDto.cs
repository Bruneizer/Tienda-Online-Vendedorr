namespace Api.Funcionalidades.Vendedores;

public class VendedorQueryDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string CUIT { get; set; }
    public string NombreUsuario { get; set; }
}

public class VendedorCommandDto
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Email { get; set; }
    public required string CUIT { get; set; }
    public required string NombreUsuario { get; set; }
    public string? Contraseña { get; set; }
}


public class VendedorContraseña
{
    public required string Contraseña { get; set; }
}
