usi// Principio Abierto / Cerrado

// SIn OCP

public class CalculadoraPrestamo
{
    public decimal Calcular(Libro libro, string tipoPrestamo)
    {
        if (tipoPrestamo == "Regular")
        {
            return 10.0m;
        }
        if (tipoPrestamo == "Premium")
        {
            return 5.0m;
        }
        throw new ArgumentException("Tipo De Prestamo No Valido");
    }
}

// APLICANDO OCP
public interface IPrestamo
{
    decimal CalcularTarifa(LibrosSRP librosSRP);
}

public class PrestamoRegular : IPrestamo
{
    public decimal CalcularTarifa(LibrosSRP librosSRP)
    {
        return 10.0m;
    }
}

public class PrestamoPremium : IPrestamo
{
    public decimal CalcularTarifa(LibrosSRP librosSRP)
    {
        return 5.0m;
    }
}

public class CalculadoraPrestamoOCP
{
    public decimal Calcular(LibroSRP libro, IPrestamo tipoPrestamo)
    {
        return tipoPrestamo.CalcularTarifa(libro);
    }
}