namespace Biblioteca;

public class Vendedor
{
    public string Nombre {get;set;}
    public string Apellido {get;set;}
    public string Email {get;set;}
    public string CUIT {get;set;}
    public string Domicilio {get;set;}
    public string NombreUsuario {get;set;}
    public string Contraseña {get;set;}
    public List<Producto> productos { get; set; }

    public Vendedor (string Nombre, string Apellido, string Email, string CUIT, string Domicilio, string NombreUsuario, string Contraseña, Producto productos)
    {
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Email = Email;
        this.CUIT = CUIT;
        this.Domicilio = Domicilio;
        this.NombreUsuario = NombreUsuario;
        this.Contraseña = Contraseña;
        this.productos = new List<Producto>(); 
    }

    
}