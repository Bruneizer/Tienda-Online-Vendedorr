using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio;

[Table("Vendedor")]
public class Vendedor
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [StringLength(50)]
    public required string Nombre {get;set;}

    [Required]
    [StringLength(50)]
    public required string Apellido {get;set;}

    [Required]
    [StringLength(50)]
    public required string Email {get;set;}

    [Required]
    [StringLength(11)]
    public required string CUIT {get;set;}
    public string Domicilio {get;set;} = string.Empty;

    [Required]
    [StringLength(50)]
    public required string NombreUsuario {get;set;}

    [Required]
    [StringLength(50)]
    public required string Contraseña {get;set;}
    public List<Producto> productos { get; set; } = [];
    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    public void EliminarProducto(Producto producto)
    {
        productos.Remove(producto);
    }

}