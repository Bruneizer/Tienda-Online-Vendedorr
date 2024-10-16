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
    public required decimal Precio { get; set; }
    
    [Required]
    public required int CantidadStock { get; set; }
    public string Imagen { get; set; } = "";
    
    [Required]
    public required Categoria categoria { get; set; }

    public void ModificarStock(int cantidad)
    {
        CantidadStock = cantidad;
    }

    public void ModificarPrecio(decimal nuevoPrecio)
    {
        Precio = nuevoPrecio;
    }
}