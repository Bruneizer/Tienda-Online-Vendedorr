using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio;


[Table("Producto")]
public class Producto
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [StringLength(50)]
    public required string Nombre { get; set; }

    public string Descripcion { get; set; } = "";
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public required decimal Precio { get; set; }
    
    [Required]
    public required int CantidadStock { get; set; }
    public string Imagen { get; set; } = "";
    
    [Required]
    public Categoria categoria { get; set; }

    public void ModificarStock(int cantidad)
    {
        CantidadStock = cantidad;
    }

    public void ModificarPrecio(decimal nuevoPrecio)
    {
        Precio = nuevoPrecio;
    }

    [StringLength(2083)] // Longitud máxima para URLs
    public string? ImagenUrl { get; set; }
}