using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio;


[Table("Categoria")]
public class Categoria
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required string Nombre { get; set; }

    [Required]
    public required List<Producto> productos {get; set;} = new List<Producto>();

}