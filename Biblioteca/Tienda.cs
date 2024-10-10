namespace Biblioteca;

public class Tienda
{
    public List<Vendedor> vendedores {get; set;}
    public List<Producto> Productos { get; set; }
    public Vendedor Vendedor { get; set; }
    public required string Nombre { get; set; }

    public Tienda ()
    {
        this.vendedores = new List<Vendedor> ();
    }
}