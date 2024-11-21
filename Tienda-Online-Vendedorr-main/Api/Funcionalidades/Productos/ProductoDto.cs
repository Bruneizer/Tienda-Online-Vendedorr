namespace Api.Funcionalidades.Productos;
public class ProductoQueryDto{
    public Guid Id { get; set;}
    public required string Nombre { get; set;}
    public required decimal Precio { get; set;}
    public required int CantidadStock { get; set;}
    public string Descripcion { get; set;} = "";
    public required string Categoria { get; set; }
    public string? ImagenUrl { get; set; }
}

public class ProductoCommanDto{
    public required string Nombre { get; set;}
    public required decimal Precio { get; set;}
    public required int CantidadStock { get; set;}
    public string Descripcion { get; set;} = "";
    public Guid IdCategoria { get; set; }
    public Guid Id { get; internal set; }
}