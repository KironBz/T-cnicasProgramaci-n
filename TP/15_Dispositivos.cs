/* dispositivos:
    lampara (ajustable brillo)
    ventilador (ajustable velocidad), 
    altavoces (reproduciendo musica; de parametro una cancion y que diga que se esata reproduciendo)
 encender/apagar, mostrar estado actual
*/

using static System.Runtime.InteropServices.JavaScript.JSType;

public interface IDispositivoInteligente
{
    // Atributos y Propiedades
    // Constructor
    // Metodos
    void Encender();
    void Apagar();
    void MostrarEstado();
}

public class Lampara : IDispositivoInteligente
{
    // Atributos
    private string nombre; 
        private bool encendido;
        private int estado;

    // Propiedades
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public bool Encendido { get; set; }
    
    public int Estado { get; set; }

    // Constructor
    public Lampara(string nombre, int estado)
    {
        this.Nombre = nombre;
        this.Estado = estado;
        this.Encendido = false; //inicia en false
    }

    // Metodos
    public void Encender()
    {
        Encendido = true;
        Console.WriteLine($"Lampara MHS Encendida");
    }
    public void Apagar()
    {
        Encendido= false;
        Console.WriteLine($"Lampara MHS Apagada");
    }

    public void AjustarBrillo()
    {
        
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"La Lampara:");
    }
}


// Para el estado general debe de ir en una lista con un foreach