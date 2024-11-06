namespace Api.Funcionalidades.Productos;
public class ProductoQueryDto{
    public Guid Id { get; set;}
   public required string Nombre { get; set;}
    public required decimal Precio { get; set;}
    public required int cantidad { get; set;}
    public string Descripcion { get; set;} = "";

}
public class ProductoCommanDto{
    public required string Nombre { get; set;}
    public required decimal Precio { get; set;}
    public required int cantidad { get; set;}
    public string Descripcion { get; set;} = "";

}