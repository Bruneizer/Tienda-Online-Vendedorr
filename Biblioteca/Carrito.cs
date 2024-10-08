namespace Biblioteca;

public class Carrito
{
    public List<Producto> productos { get; set; }
    public int Cantidad {get; set;}

    public Carrito ()
    {
        this.productos = new List<Producto> ();
        this.Cantidad = 0;
    }
}