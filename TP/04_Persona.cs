public class Persona
{
    // Atributos
public string Nombre{ get; set; } //Encapsulamiento
public int Edad{ get; set; }

    // Atributo static
    public static string Pais { get; set; } = "España";

// Constructro
public Persona (string nombre, int edad, string pais)
    {
        Nombre = nombre;
        Edad = edad;
        Pais = pais;
    }

// Metodos
public void MostrarDatos()
    {
        Console.WriteLine($"Nombre  Objeto: {Nombre}");
        Console.WriteLine($"Edad  Objeto: {Edad}");

    }

    public static void MostrarPais()
    {
        Console.WriteLine($"Pais  Objeto: {Pais}");
    }

}