using Api.Persistencia;
using Biblioteca.Dominio;
using Biblioteca.Validaciones;
using BCrypt.Net;

namespace Api.Funcionalidades.Vendedores;


    public interface IVendedorService
{
    List<VendedorQueryDto> GetVendedor();
    void CreateVendedor(VendedorCommandDto vendedorDto);
    void UpdateVendedor(Guid IdVendedor, VendedorCommandDto vendedorDto);
    void DeleteVendedor(Guid IdVendedor);
}
public class VendedorService : IVendedorService
{
    private readonly TiendaVendedorDbContext context;

    public VendedorService(TiendaVendedorDbContext context)
    {
        this.context = context;
    }
    public void CreateVendedor(VendedorCommandDto vendedorDto)
    {
        Guard.Validaciones(vendedorDto.Nombre, "El nombre del vendedor no puede ser vacio");
        Guard.Validaciones(vendedorDto.Apellido, "El apellido del vendedor no puede ser vacio");
        Guard.Validaciones(vendedorDto.Email, "El email del vendedor no puede ser vacio");
        Guard.Validaciones(vendedorDto.CUIT, "El CUIT del vendedor no puede ser vacio");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(vendedorDto.Contraseña);

        var vendedor = new Vendedor
        {
            Nombre = vendedorDto.Nombre,
            Apellido = vendedorDto.Apellido,
            Email = vendedorDto.Email,
            CUIT = vendedorDto.CUIT,
            NombreUsuario = vendedorDto.NombreUsuario,
            Contraseña = hashedPassword
        };

        context.Vendedores.Add(vendedor);
        context.SaveChanges();
    }

    public void DeleteVendedor(Guid IdVendedor)
    {
         var vendedor = context.Vendedores.SingleOrDefault(x => x.Id == IdVendedor);
        if (vendedor is not null)
        {
            context.Vendedores.Remove(vendedor);
            context.SaveChanges();
        }
    }

    public List<VendedorQueryDto> GetVendedor()
    {
        return context.Vendedores.Select(vendedores => new VendedorQueryDto
        {
            Id = vendedores.Id,
            Nombre = vendedores.Nombre,
            Apellido = vendedores.Apellido,
            Email = vendedores.Email,
            CUIT = vendedores.CUIT,
            NombreUsuario = vendedores.NombreUsuario,
            Contraseña = vendedores.Contraseña,
        }).ToList();
    }

    public void UpdateVendedor(Guid IdVendedor, VendedorCommandDto vendedorDto)
    {
         var vendedor = context.Vendedores.SingleOrDefault(x => x.Id == IdVendedor);
        if (vendedor is not null)
        {
            vendedor.Nombre = vendedorDto.Nombre;
            context.SaveChanges();
        }
    }
}