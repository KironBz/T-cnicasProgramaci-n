// Programa Principal
Estudiante estudiante = new Estudiante
{
    Id = 1,
    Nombre = "Pancho Villa",
    Edad = 20,
    Calificacion = 10.0 // decimal por ser double
};

// No vi como pero se puede editar desde el block de notas y puede extraer los archivos modificados de forma permanente

Console.WriteLine("objeto");
Console.WriteLine(estudiante);
Console.WriteLine("metodo");
Console.WriteLine(estudiante.ToString());

// Configuracion inicial
string archivoEstudiantes = "estudiantes.txt";
GestorEstudiantes gestor = new GestorEstudiantes(archivoEstudiantes);

// Crear una lista de estudiantes de ejemplo
List<Estudiante> estudiantes = new List<Estudiante>
{
    new Estudiante{ Id = 1 , Nombre = "Diego Garcia" , Edad = 22 , Calificacion = 6.0 },
    new Estudiante{ Id = 2 , Nombre = "Luis Romero" , Edad = 21 , Calificacion = 7.8 },
    new Estudiante{ Id = 3 , Nombre = "Elias Vasquez" , Edad = 20 , Calificacion = 8.0 },
    new Estudiante{ Id = 4 , Nombre = "Bruno Lopez" , Edad = 20 , Calificacion = 5.0 },
    new Estudiante{ Id = 5 , Nombre = "Dario Pineda", Edad = 20 , Calificacion = 8.1 }
};

// Guardar Estudiantes
Console.WriteLine("Guardando Estudiantes...");
gestor.GuardarEstudiantes(estudiantes);


// Leer todos los estudiantes en archivo
Console.WriteLine("Leyendo Estudiantes...");
var estudiantesLeidos = gestor.LeerEstudiantes();
foreach(var estudiant in estudiantesLeidos)
{
    Console.WriteLine(estudiant);
}

// Buscar estudiante por ID
Console.WriteLine("Buscando estudiante con ID 4");
var estudianteEncontrado = gestor.BuscarEstudiantePorId(4);
if(estudianteEncontrado != null)
{
    Console.WriteLine(estudianteEncontrado);
}
else
{
    Console.WriteLine("Estudiante No Encontrado");
}


// Clase que representa Estudiantes
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
        return $"{Id},{Nombre},{Edad},{Calificacion}";
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
    public void GuardarEstudiantes(List<Estudiante> estudiantes)
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
            Console.WriteLine("Estudiantes guardados correctamente");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //Metodos para leer la lista
    public List<Estudiante> LeerEstudiantes()
    {
        List<Estudiante> estudiantesLectura = new List<Estudiante>();

        try
        {
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string lineaLectura;

                    while ((lineaLectura = reader.ReadLine()) !=null ) 
                    {
                        // DIvidiendo la linea por las comas
                        

                        string[] datos = lineaLectura.Split(',');

                        if (datos.Length == 4)
                        {
                            estudiantesLectura.Add(new Estudiante
                            {
                                Id = int.Parse(datos[0]),
                                Nombre = datos[1],
                                Edad = int.Parse(datos[2]),
                                Calificacion = double.Parse(datos[3])
                            });
                        }
                    }
                }

                Console.WriteLine("Estudiantes leidos correctamente");
            }
            else
            {
                Console.WriteLine("Archivo no encontrado en la ruta");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return estudiantesLectura;
    }

    // Metodo para buscar un estudiante por ID
    public Estudiante BuscarEstudiantePorId(int id)
    {
        try
        {
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string lineaLectura;

                    while ((lineaLectura = reader.ReadLine()) !=null ) 
                    {
                        // DIvidiendo la linea por las comas
                        string[] datos = lineaLectura.Split(',');

                        if (datos.Length == 4 && int.Parse(datos[0]) == id)
                        {
                            return new Estudiante
                            {
                                Id = int.Parse(datos[0]),
                                Nombre = datos[1],
                                Edad = int.Parse(datos[2]),
                                Calificacion = double.Parse(datos[3])
                            };
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Retorna nulo si no enuentra 
        return null;
    }

}
