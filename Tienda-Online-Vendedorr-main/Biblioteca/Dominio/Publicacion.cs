using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio;

[Table("Publicacion")]
public class Publicacion
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("ProductoId")]
    public Producto producto { get; set; }
    public Guid ProductoId { get; set; }

    [Required]
    public bool Activo { get; set; }

    [ForeignKey("VendedorId")]
    public Vendedor Vendedor { get; set; }
    public Guid VendedorId { get; set; }

    // Agregar campo URL a la entidad
    public string Url { get; set; } // Nuevo campo
}
