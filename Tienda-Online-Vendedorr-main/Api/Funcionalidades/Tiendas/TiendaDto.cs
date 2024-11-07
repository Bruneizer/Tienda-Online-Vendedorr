namespace Api.Funcionalidades.Tiendas;

public class TiendaQueryDto
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
}

public class TiendaCommandDto
{
    public required string Nombre { get; set; }
}