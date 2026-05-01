// Principio de una sola responsabilidad, debera tener una responsabilidad por clase

// Sin SRP

public class Libro()
{
    // Atributos y Porpiedades, son 3 responsabilidades, una por atributo

    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int paginas { get; set; }

    // Metodos
    public void GuardarBD()
    {
        // Ejemplo de implementacion en BD
        Console.WriteLine($"Guardando {Titulo} en BD.");
    }

    public void GenerarReporte()
    {
        Console.WriteLine($"Reporte para {Titulo} por {Autor}");
    }
}

// Aplicando SRP para tener una responsabilidad por clase

// Primera responsabilidad, instanciar objeto libro con encapsulamiento de atributos
public class LibroSRP
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Paginas { get; set; }
}

// Segunda Responsabilidad
public class RepositorioLiobro
{
    public void GuardarBD(LibroSRP libroSRP)
    {
        // Codigo para BasedeDatos (BD)
        Console.WriteLine($"GUardando {libroSRP.Titulo} en BD.");
    }
}

// TErcera responsabilidad generar reportes
public class GeneradorReporte
{
    public void GenerarReporte(LibroSRP libroSRP)
    {
        Console.WriteLine($"Reporte para {libroSRP.Titulo}");
    }
}