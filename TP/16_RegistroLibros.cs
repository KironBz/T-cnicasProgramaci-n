// clase libro que tendra las propiedaes de los libros: titulo autor genero
// Programa Principal
/// <summary>
///  ASDFGASDFG
/// </summary>



// Clases
public class Libro
{
    // Atributos y Propiedades
    public string Titulo { get; } // El set se va porque no deberia modificarse despues, pero si leerse
    public string Autor { get; }
    public string Genero { get; }

    // Variables de clase
    List<int> Calificaciones; // variable que ayuda a saber el promedio de cada libro; solo esta declarada, sin instanciar

    // Constuctor
    public Libro(string titulo, string autor, string genero)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Calificaciones = new List<int>(); // Se instancia la nueva lista vacia de calificaciones
    }

    // Metodos
    public void Calificar(int estrellas)
    {
        if (estrellas >= 1 && estrellas <= 5)
        {
            Calificaciones.Add(estrellas);
        }
        else
        {
            throw new ArgumentException("Calificación Invalida ( 1 - 5 )");
        }
    }
    // Sobrecarga del metodo calificar
    public void Calificar(int estrellas, string comentario)
    {
        Console.WriteLine($"Comentario Recibido: {comentario}");
        // PAra no copiar el if, solo se manda a llamar el metodo
        Calificar(estrellas);
    }

    public double ObtenerPromedio()
    {
        if (Calificaciones.Count == 0) //cuantos valores hay en la lista
        {
            throw new InvalidOperationException("No Hay Calificaciones Aun Para Este Libro");
        }
        else
        {
            double promedio = Calificaciones.Average();
            return promedio;
        }
    }

    public int ObtenerCantidadVotos()
    {
        return Calificaciones.Count; // cont regresa el numero de votos que tiene el libro
    }
}

// CLases Hijas Tipos De Libros
public class LIbroFiccion : Libro
{
    // Variable de Clase
    List<string> tipoFiccion = new List<string> {"Fantasia", "Ciencia_Ficcion", "Misterio" ,"Romance", "Terror" };

    // Constructor
    public LIbroFiccion(string titulo, string autor, string genero) : base (titulo, autor, genero)
    {
        if (!tipoFiccion.Contains(genero))
        {
            throw new ArgumentException("El Libro No Pertenece A Esta Categoria");
        }
    }
}

public class LIbroTecnico : Libro
{
    // Variable de Clase
    List<string> tipoTecnico = new List<string> { "Matemáticas", "Historia", "Programación", "Filosofía", "Medicina" };

    // Constructor
    public LIbroTecnico(string titulo, string autor, string genero) : base(titulo, autor, genero)
    {
        if (!tipoTecnico.Contains(genero))
        {
            throw new ArgumentException("El Libro No Pertenece A Esta Categoria");
        }
    }
}

// interface para criterio de recomendacion
interface IRecomendable 
{
    Libro ObtenerMejorLibro(List<Libro> libros); //No entendi
}

// Clases de Recomendacion Por VOtos Y De Recomendacion por Promedios
public class RecomendacionPorPromedio : IRecomendable
{
    public Libro ObtenerMejorLibro(List<Libro> libros)
    {
        Libro mejorLibro = null;
        double mejorPromedio = 0; // Pivote, debe ser menor a la menor calificacion 0 < (1-5)

        foreach ( Libro libro in libros)
        {
            double promedio = libro.ObtenerPromedio(); // Seleccion del pivote, ordenamiento burbuja
            if(promedio > mejorPromedio) // Comparacion
            {
                mejorPromedio = promedio;
                mejorLibro = libro;
            }
        }

        return mejorLibro;
    }
}

public class RecomendacionPorVotos : IRecomendable
{
    public Libro ObtenerMejorLibro(List<Libro> libros)
    {
        Libro mejorLibro = null;
        double maxVotos = -1; // Pivote, debe ser menor a la menor calificacion -1 < 0 votos

        foreach (Libro libro in libros)
        {
            int votos = libro.ObtenerCantidadVotos(); // Seleccion del pivote, ordenamiento burbuja
            if (votos > maxVotos) // Comparacion
            {
                maxVotos = votos;
                mejorLibro = libro;
            }
        }
        return mejorLibro;
    }
}

// Clase de Libreria
public class Libreria
{
    public List<Libro> Libros = new List<Libro>();
    IRecomendable estrategiaRecomendacion = new RecomendacionPorPromedio();
    
    // Metodos
    public void AgrafarLibro(string titulo, string autor, string genero)
    {

        Libro nuevoLibro; 

        try
        {
            nuevoLibro = new LIbroFiccion(titulo, autor, genero);
            Libros.Add(nuevoLibro);
        }
        catch (Exception ex)
        {
            nuevoLibro = new LIbroTecnico(titulo, autor, genero);
            Libros.Add(nuevoLibro);
        }
    }

    public void CalificarLibro(string titulo, int estrellas)
    {
        Libro libroEncontrado = null;
        foreach (Libro libro in Libros)
        {
            if (libro.Titulo == titulo)
            {
                libroEncontrado = libro;
                break;
            }
        }

        if (libroEncontrado != null)
        {
            libroEncontrado.Calificar(estrellas);
        }
        else
        {
            throw new KeyNotFoundException("Libro No Encontrado");
        }
    }

    // SObrecarga
    public void CalificarLibro(string titulo, int estrellas, string comentario)
    {
        Libro libroEncontrado = null;
        foreach (Libro libro in Libros)
        {
            if (libro.Titulo == titulo)
            {
                libroEncontrado = libro;
                break;
            }
        }

        if (libroEncontrado != null)
        {
            libroEncontrado.Calificar(estrellas, comentario);
        }
        else
        {
            throw new KeyNotFoundException("Libro No Encontrado");
        }
    }
}