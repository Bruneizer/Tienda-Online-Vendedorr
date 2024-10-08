namespace Biblioteca;

public class Compra : Carrito
{
    public Vendedor Vendedor { get; set; }
    public DateTime Fecha { get; set; }
    public decimal PrecioTotal { get; set; }

    public Compra(Vendedor vendedor, List<Producto> productos, int cantidad) : base()
    {
        Vendedor = vendedor;
        Fecha = DateTime.Now;       
        PrecioTotal = CalcularPrecioTotal();
    }

    public decimal CalcularPrecioTotal()
    {
        decimal total = 0;
        foreach (var produc in productos) 
        {
            total += produc.Precio * Cantidad; 
        }
        return total;
    }
}