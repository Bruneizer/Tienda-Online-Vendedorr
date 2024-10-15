using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio;

[Table("Publicacion")]
public class Publicacion
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Producto producto { get; set; }
    
    [Required]
    public required bool Activo { get; set; }

    public void ActivarPublicacion()
    {
        Activo = true;
    }

    public void DesactivarPublicacion()
    {
        Activo = false;
    }
}