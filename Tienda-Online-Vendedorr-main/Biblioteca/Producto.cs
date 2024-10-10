namespace Biblioteca;

public class Producto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int CantidadStock { get; set; }
    public string Imagen { get; set; }
    public Categoria categoria { get; set; }

    public Producto(string Nombre, string Descripcion, decimal Precio, int CantidadStock, string Imagen)
    {
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.Precio = Precio;
        this.CantidadStock = CantidadStock;
        this.Imagen = Imagen;
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