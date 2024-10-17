
using Api.Persistencia;
using Biblioteca.Dominio;

namespace Api.Funcionalidades.Categorias;
public interface ICategoriaService
{
    void CreateCategoria(CategoriaCommandDto categoriaDto);
    void DeleteCategoria(Guid idCategoria);
    void UpdateCategoria(Guid idCategoria, CategoriaCommandDto categoriaDto);
    List<CategoriaQueryDto> GetCategoria();

}

public class CategoriaService : ICategoriaService
{
    private readonly TiendaVendedorDbContext context;

    public CategoriaService(TiendaVendedorDbContext context )
    {
        this.context = context;
    }
    public void CreateCategoria(CategoriaCommandDto categoriaDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteCategoria(Guid idCategoria)
    {
        throw new NotImplementedException();
    }

    public List<CategoriaQueryDto> GetCategoria()
    {
        return context.Categorias.Select(categoria => new CategoriaQueryDto{
            Id = categoria.Id,
            Nombre = categoria.Nombre
        }).ToList();
        
    }

    public void UpdateCategoria(Guid idCategoria, CategoriaCommandDto categoriaDto)
    {
        throw new NotImplementedException();
    }
}