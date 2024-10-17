namespace Api.Funcionalidades.Categorias;

public class CategoriaQueryDto 
{
    public Guid Id{ get; set; }
    public required string Nombre { get; set; }
    
}

public class CategoriaCommandDto
{
    public required string Nombre { get; set; }

}