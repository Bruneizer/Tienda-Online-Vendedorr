using Api.Persistencia;
using Biblioteca.Dominio;
using Biblioteca.Validaciones;
using BCrypt.Net;

namespace Api.Funcionalidades.Vendedores;


public interface IVendedorService
{
    List<VendedorQueryDto> GetVendedor();
    void CreateVendedor(VendedorCommandDto vendedorDto);
    void UpdateVendedor(Guid idVendedor, VendedorCommandDto vendedorDto);
    void DeleteVendedor(Guid idVendedor);
}


public class VendedorService : IVendedorService
{
    private readonly TiendaVendedorDbContext context;

    public VendedorService(TiendaVendedorDbContext context)
    {
        this.context = context;
    }

    public List<VendedorQueryDto> GetVendedor()
    {
        return context.Vendedores
            .Select(v => new VendedorQueryDto
            {
                Id = v.Id,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Email = v.Email,
                CUIT = v.CUIT,
                NombreUsuario = v.NombreUsuario
            })
            .ToList();
    }

    public void CreateVendedor(VendedorCommandDto vendedorDto)
    {
        Guard.Validaciones(vendedorDto.Nombre, "El nombre del vendedor no puede ser vacío");
        Guard.Validaciones(vendedorDto.Apellido, "El apellido del vendedor no puede ser vacío");
        Guard.Validaciones(vendedorDto.Email, "El email del vendedor no puede ser vacío");
        Guard.Validaciones(vendedorDto.CUIT, "El CUIT del vendedor no puede ser vacío");

        if (string.IsNullOrWhiteSpace(vendedorDto.Contraseña))
        {
            throw new ArgumentException("La contraseña no puede ser vacía");
        }

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

    public void UpdateVendedor(Guid idVendedor, VendedorCommandDto vendedorDto)
    {
        var vendedor = context.Vendedores.Find(idVendedor);
        if (vendedor == null)
        {
            throw new KeyNotFoundException("Vendedor no encontrado.");
        }

        vendedor.Nombre = vendedorDto.Nombre;
        vendedor.Apellido = vendedorDto.Apellido;
        vendedor.Email = vendedorDto.Email;
        vendedor.CUIT = vendedorDto.CUIT;
        vendedor.NombreUsuario = vendedorDto.NombreUsuario;

        if (!string.IsNullOrWhiteSpace(vendedorDto.Contraseña))
        {
            vendedor.Contraseña = BCrypt.Net.BCrypt.HashPassword(vendedorDto.Contraseña);
        }

        context.SaveChanges();
    }

    public void DeleteVendedor(Guid idVendedor)
    {
        var vendedor = context.Vendedores.Find(idVendedor);
        if (vendedor == null)
        {
            throw new KeyNotFoundException("Vendedor no encontrado.");
        }

        context.Vendedores.Remove(vendedor);
        context.SaveChanges();
    }
}

