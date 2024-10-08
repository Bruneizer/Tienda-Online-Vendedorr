namespace Biblioteca;

public class Tienda
{
    public List<Vendedor> vendedores {get; set;}

    public Tienda ()
    {
        this.vendedores = new List<Vendedor> ();
    }
}