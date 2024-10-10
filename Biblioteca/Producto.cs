namespace Biblioteca;

public class Producto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string Categoria { get; set; }
    public int CantidadStock { get; set; }
    public string URL { get; set; }

    public required List<Tienda> Tiendas { get; set; }

    public Producto(string Nombre, string Descripcion, decimal Precio, string Categoria, int CantidadStock, string URL)
    {
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.Precio = Precio;
        this.Categoria = Categoria;
        this.CantidadStock = CantidadStock;
        this.URL = URL;
    }

    public void ModificarStock(int cantidad)
    {
        CantidadStock = cantidad;
    }

    public void ModificarPrecio(decimal nuevoPrecio)
    {
        Precio = nuevoPrecio;
    }
}