namespace Biblioteca;

public class Publicacion
{
    public Producto producto { get; set; }
    public bool Activo { get; set; }

    public Publicacion (Producto producto)
    {
        this.producto = producto;
        this.Activo = Activo;
    }

    public void ActivarPublicacion()
    {
        Activo = true;
    }

    public void DesactivarPublicacion()
    {
        Activo = false;
    }
}