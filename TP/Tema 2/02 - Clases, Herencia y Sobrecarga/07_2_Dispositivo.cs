//Programa Principal
Lampara lampara = new Lampara("Lamparita", 80, 400);
Ventilador ventilador = new Ventilador("Aire", 500, 50);

// Encender ambos dispositivos
lampara.Encender();
ventilador.Encender();

// Mostrar informacion pt 1
Console.WriteLine(lampara.MostrarInfo());
Console.WriteLine(ventilador.MostrarInfo());

// Ajustar consumo
lampara.AjustarConsumo();
ventilador.AjustarConsumo(150);

// Mostrar informacion pt 2
Console.WriteLine(lampara.MostrarInfo());
Console.WriteLine(ventilador.MostrarInfo());

// Comparacion con operadores
if (lampara > ventilador)
{
    Console.WriteLine("Lamapara consume mas");
}
else if (lampara < ventilador)
{
    Console.WriteLine("Venitlador consume mas");
}
else
{
    Console.WriteLine("Ambos consumen la misma energia");
}

public class Dispositivo
{
    // Atributos - Campos
    private string nombre;
    private bool encendido;
    private int consumo;
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
    public int Consumo
    {
        get { return encendido ? consumo : 0; } // solo consume si esta encendido; ternaria true consumo, false 0 -> No se que hacia este de aqui, pero estorba
        set
        {
            if (value < 0)
            {
                consumo = 0;
            }
            else
            {
                consumo = value;
            }
        }
    }
    // Constructor
    public Dispositivo(string nombre, int consumo)
    {
        this.nombre = nombre;
        this.consumo = consumo;
        this.encendido = false; //inicia en false
    }
    // Metodos
    public void Encender()
    {
        Encendido = true;
    }
    public void Apagar()

    {
        Encendido = false;
    }
    // Sobrecarga
    public void AjustarConsumo()
    {
        Consumo = 100;
    }
    public void AjustarConsumo(int nuevoconsumo) //sobrecargado con el parametro
    {
        Consumo = nuevoconsumo;
    }
    // Herencia
    public virtual string MostrarInfo()
    {
        return $"Dispositivo: {Nombre}, Encendido: {Encendido}, Consumo; {Consumo} [W]";
    }
    // Sobrecarga de operadores <> , == ¡=
    public static bool operator >(Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo > d2.Consumo;
    }
    public static bool operator <(Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo < d2.Consumo;
    }
    public static bool operator ==(Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo == d2.Consumo;
    }
    public static bool operator !=(Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo != d2.Consumo;
    }
}

public class Lampara : Dispositivo
{
    // Atributos - Campo y Propiedaes
    private int intensidad; // Nivel de brillo
                            // Constructor
    public Lampara(string nombre, int consumo, int intensidad) : base(nombre, consumo)
    {
        this.intensidad = intensidad;
    }

    // Metodos
    public override string MostrarInfo()
    {
        return $"Lampara: {base.MostrarInfo()}, Intensidad: {intensidad}";
    }
}
public class Ventilador : Dispositivo
{
    // Atributos - Campo y Propiedaes
    private int velocidad; // Nivel de velocidad
                           // Constructor
    public Ventilador(string nombre, int consumo, int velocidad) : base(nombre, consumo)
    {
        this.velocidad = velocidad;
    }
    // Metodos
    public override string MostrarInfo()
    {
        return $"Ventilador: {base.MostrarInfo()}, Velocidad: {velocidad}";
    }
}