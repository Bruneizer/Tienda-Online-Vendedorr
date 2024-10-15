using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio;


[Table("Tienda")]
public class Tienda
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Vendedor> Vendedores {get; set;} = new List<Vendedor>();
    public List<Producto> Productos { get; set; } = new List<Producto>();

    [Required]
    public required string Nombre { get; set; }

}