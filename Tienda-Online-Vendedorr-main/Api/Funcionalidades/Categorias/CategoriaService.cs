
using Api.Persistencia;
using Biblioteca.Dominio;
using Biblioteca.Validaciones;

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

    public CategoriaService(TiendaVendedorDbContext context)
    {
        this.context = context;
    }
    public List<CategoriaQueryDto> GetCategoria()
    {
        return context.Categorias.Select(categoria => new CategoriaQueryDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre
        }).ToList();

    }

    public void CreateCategoria(CategoriaCommandDto categoriaDto)
    {
        Guard.Validaciones(categoriaDto.Nombre, "El nombre de la categoria no puede ser vacia");
        Categoria nuevaCategoria = new Categoria()
        {
            Nombre = categoriaDto.Nombre
        };
        context.Categorias.Add(nuevaCategoria);
        context.SaveChanges();
    }

    public void DeleteCategoria(Guid idCategoria)
    {
        var categoria = context.Categorias.SingleOrDefault(x => x.Id == idCategoria);
        if (categoria is not null)
        {
            context.Categorias.Remove(categoria);
            context.SaveChanges();
        }
    }

    public void UpdateCategoria(Guid idCategoria, CategoriaCommandDto categoriaDto)
    {
        var categoria = context.Categorias.SingleOrDefault(x => x.Id == idCategoria);
        if (categoria is not null)
        {
            categoria.Nombre = categoriaDto.Nombre;
            context.SaveChanges();
        }
    }
}