// Clase que representa Estudiantes

using System.Runtime.CompilerServices;

public class Estudiante
{
    // Atributos
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public double Calificacion { get; set; }

    // Constructor

    // Metodos
    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Edad: {Edad}, Calificacion: {Calificacion}";
    }
}

// Clase para manejar el arhivo de estudiantes

public class GestorEstudiantes
{
    // ATributos
    private string rutaArchivo;

    // COnstructor
    public GestorEstudiantes(string ruta)
    {
        rutaArchivo = ruta;
    }

    // Metodo para guardar la lista de estudiantes en un archivo

    public void GuardarEstudiantes(List<Estudiantes> estudiantes)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                foreach (Estudiante estudiante in estudiantes)
                {
                    writer.WriteLine(estudiante.ToString());
                }    
            }
            Console.WriteLine("Estudiantes no se que mas");

        }
        catch
        {

        }
    }

}