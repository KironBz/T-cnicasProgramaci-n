// Programa Principal
List<IDispositivoInteligente> Dispositivos = new List<IDispositivoInteligente>();

Lampara lamparauno = new Lampara("Lamp", true);
Dispositivos.Add(lamparauno);

Ventilador ventiladoruno = new Ventilador("Venti");
Dispositivos.Add(ventiladoruno);

Altavoz altavozuno = new Altavoz("Alt", true, true);
Dispositivos.Add(altavozuno);
altavozuno.Cancion = "DotA";

Altavoz altavozdos = new Altavoz("Alban", false, false);
Dispositivos.Add(altavozdos);
altavozdos.Cancion = "Sin Titulo";


foreach (IDispositivoInteligente encendiendo in Dispositivos)
{
    encendiendo.Encender();
}

Console.WriteLine();

foreach (IDispositivoInteligente estados in Dispositivos)
{
    estados.MostrarEstado();
}

Console.WriteLine();
Console.WriteLine();
lamparauno.AjustarBrillo(75);
ventiladoruno.AjustarVelocidad(3);
altavozdos.Song("La Carencia");
Console.WriteLine();

foreach (IDispositivoInteligente apagando in Dispositivos)
{
    apagando.Apagar();
}


Console.WriteLine();
foreach (IDispositivoInteligente estados in Dispositivos)
{
    estados.MostrarEstado();
}

// Interfaces 
public interface IDispositivoInteligente
{
    void Encender();
    void Apagar();
    void MostrarEstado();
}

//Clases
public class Lampara : IDispositivoInteligente
{
    // Atributos
    private string nombre;
    private bool encendido;
    private int brillo;

    // Propiedades
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public bool Encendido
    {
        get { return encendido; }
        set { encendido = value; }
    }

    public int Brillo
    {
        get { return brillo; }

        set
        {
            if (value >= 0 && value <= 100)
            {
                brillo = value;

                if (brillo > 0)
                {
                    encendido = true;
                }
                else
                {
                    encendido = false;
                }
            }
        }
    }

    // Constructor
    public Lampara(string nombre)
    {
        Nombre = nombre;
        // Encendido = false; // Redundancia con el set del brillo
        Brillo = 0;
    }

    // Sobrecarga del constructor
    public Lampara(string nombre, bool encendido)
    {
        Nombre = nombre;
        if (encendido == true)
        {
            Brillo = 50;
        }
        else
        {
            Brillo = 0;
        }
    }

    public Lampara(string nombre, bool encendido, int brillo)
    {
        Nombre = nombre;
        if (encendido == true)
        {
            Brillo = brillo;
        }
        else
        {
            Brillo = 0;
        }       
    }

    // Metodos
    public void Encender()
    {
        // Encendido =true;
        Brillo = 50;
        Console.WriteLine($"Lampara: {Nombre} Encendida");
    }
    public void Apagar()
    {
        // Encendido= false;
        Brillo = 0;
        Console.WriteLine($"Lampara: {Nombre} Apagada");
    }

    public void MostrarEstado()
    {
        if (Encendido == true)
        {
            Console.WriteLine($"Lampara:\n Nombre: {Nombre} | " +
                "Estado: Encendida | " +
                $"Brillo: {Brillo}%");
        }
        else
        {
            Console.WriteLine($"Lampara: \n Nombre: {Nombre} | " +
                "Estado: Apagada ");
        }
    }

    public void AjustarBrillo(int nivel)
    {
        Brillo = nivel;
        Console.WriteLine($"El Brillo De {Nombre} Ahora Es: {Brillo}% ");
    }
}

public class Ventilador : IDispositivoInteligente
{
    // Atributos
    private string nombre;
    private bool encendido;
    private int velocidad;

    // Porpiedades
    public string Nombre
    {
        get { return nombre; } 
        set { nombre = value; }
    }

    public bool Encendido
    {
        get { return encendido; }
        set { encendido = value; }
    }

    public int Velocidad
    {
        get { return velocidad; }
        set 
        {
            if (value >=0 && value <= 3)
            {
                velocidad = value;

                if (velocidad > 0)
                {
                    encendido = true;
                }
                else
                {
                    encendido= false;
                }
            }
        }
    } 
    
    // Constructor
    public Ventilador(string nombre)
    {
        Nombre = nombre;
        // Encendido = false;
        Velocidad = 0;
    }
    
    // constructor Sobrecargado
    public Ventilador(string nombre, bool encendido)
    {
        Nombre = nombre;
        if (encendido == true)
        {
            Velocidad = 2;
        }
        else
        {
            Velocidad = 0;
        }
    }
    public Ventilador(string nombre, bool encendido, int velocidad)
    {
        Nombre = nombre;
        if (encendido == true)
        {
            Velocidad = velocidad;
        }
        else
        {
            Velocidad = 0;
        }
    }

    // Metodos
    public void Encender()
    {
        // Encendido =true;
        Velocidad = 2;
        Console.WriteLine($"Ventilador: {Nombre} Encendido");
    }
    public void Apagar()
    {
        // Encendido= false;
        Velocidad = 0;
        Console.WriteLine($"Ventilador: {Nombre} Apagado");
    }

    public void MostrarEstado()
    {
        if (Encendido == true)
        {
            Console.WriteLine($"Ventilador:\n Nombre: {Nombre} | " +
                "Estado: Encendido | " +
                $"Velocidad: {Velocidad}");
        }
        else
        {
            Console.WriteLine($"Ventilador: \n Nombre: {Nombre} | " +
                "Estado: Apagado");
        }
    }

    public void AjustarVelocidad(int nivel)
    {
        Velocidad = nivel;
        Console.WriteLine($"La Velocidad De {Nombre} Ahora Es: {Velocidad}");
    }
}

public class Altavoz : IDispositivoInteligente
{
    // Atributos
    private string nombre;
    private bool encendido;
    private bool reproduciendo;
    private string cancion;

    // Propiedades
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public bool Encendido
    {
        get { return encendido; }
        set 
        {
            encendido = value;
            if (value == false)
            {
                reproduciendo = false;
            }
        }
    }

    public bool Reproduciendo
    {
        get { return  reproduciendo; }
        set 
        {

            if (encendido == true)
            {
                reproduciendo = value;
            }
            else
            {
                reproduciendo = false;
            }
        }
    }

    public string Cancion
    {
        get { return cancion;  }
        set { cancion = value; }
    }

    // Constructor
    public Altavoz(string nombre, bool encendido, bool reproduciendo)
    {
        Nombre = nombre;
        Encendido = encendido;
        Reproduciendo = reproduciendo;
    }

    // Metodos
    public void Encender()
    {
        Encendido = true;
        Console.WriteLine($"Altavoz: {Nombre} Encendido");
    }
    public void Apagar()
    {
        Encendido = false;
        Console.WriteLine($"Altavoz: {Nombre} Apagado");
    }

    public void MostrarEstado()
    {
        if (Encendido == true)
        {
            Console.Write($"Altavoz: \n Nombre: {Nombre} | " +
                "Estado: Encendido | ");
            if (Reproduciendo == true)
            {
                Console.WriteLine($"Reproduciendo: \"{Cancion}\"");                
            }
            else
            {
                Console.WriteLine("Está En Pausa... ");
            }
        }
        else
        {
            Console.WriteLine($"Altavoz: \n Nombre: {Nombre} | " +
                "Estado: Apagado");
        }
    }

    public void Song(string song)
    {
        if (Encendido)
        {
            Cancion = song;
            Reproduciendo = true;
            Console.WriteLine($"El Altavoz {Nombre} Está Reproduciendo: \"{Cancion}\"");
        }
    }
}
