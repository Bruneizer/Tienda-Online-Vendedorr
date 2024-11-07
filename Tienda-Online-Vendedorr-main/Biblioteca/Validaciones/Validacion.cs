namespace Biblioteca.Validaciones;

public static class Guard
{
    public static void Validaciones (string cadena, string MensajeError)
    {
        if(string.IsNullOrEmpty(cadena))
            throw new FormatException(MensajeError);
    }

    public static void Validaciones(decimal precio, string mensajeError)
    {
        if (precio == 0)
            throw new FormatException(mensajeError);
    }


}