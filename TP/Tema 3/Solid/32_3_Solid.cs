// Sistema de Vacunas En Una Veterinaria

var mensajeria = new EmailService();
var notificador = new Notificacion(mensajeria);
var calculadoraService = new CalculadoraVacunas();

// Perro
Console.WriteLine("Caso1 mascota comun:");
var estrategiaPerro = new CalculadoraPerro();
var sistema1 = new SistemaVeterinaria(notificador, calculadoraService, estrategiaPerro);
sistema1.AtenderMascota("Juanito", "Perro", 2);

Console.WriteLine("\n");

// Ave
Console.WriteLine("Caso2 mascota comun no contemplado:");
var estrategiaGral = new CalculadoraXDefecto();
var sistema2 = new SistemaVeterinaria(notificador, calculadoraService, estrategiaGral);
sistema2.AtenderMascota("Jorgito", "Ave", 3);

Console.WriteLine("\n");

// Rex - Perro      Ya no revienta el programa
Console.WriteLine("Caso3 mascota especial:");
var sistema3 = new SistemaVeterinariaEspecial(notificador, calculadoraService, estrategiaPerro);
sistema3.AtenderMascota("Rex", "Perro", 8);

Console.WriteLine("\n");

// Cocodrilo
Console.WriteLine("Caso4 mascota especial:");

var sistema4 = new SistemaVeterinaria(notificador, calculadoraService, estrategiaGral);
sistema4.AtenderMascota("Bolillo", "Cocodrilo", 20);

Console.WriteLine("\n");

/////////////////////////////////

// Clases Dominio
public class Mascota
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Edad { get; set; }

    public Mascota(string nombre, string tipo, int edad) // S - Tambien va solito //
    {
        Nombre = nombre;
        Tipo = tipo;
        Edad = edad;
    }
}

public class ValidadorMascota
{
    public bool EsValida(Mascota mascota) // S - Deben de ir en clases independientes //
    {
        return !string.IsNullOrEmpty(mascota.Nombre) && mascota.Edad > 0;
    }
}

public interface ICalcuadorVacunas
{
    decimal Calcular(Mascota mascota);
}

public class CalculadoraPerro : ICalcuadorVacunas
{
    public decimal Calcular(Mascota mascota) => 200;
}

public class CalculadoraGato : ICalcuadorVacunas
{
    public decimal Calcular(Mascota mascota) => 180;
}

public class CalculadoraTortuga : ICalcuadorVacunas
{
    public decimal Calcular(Mascota mascota) => 400;
}

public class CalculadoraXDefecto : ICalcuadorVacunas
{
    public decimal Calcular(Mascota mascota) => mascota.Edad * 50;
}

public class CalculadoraVacunas
{
    public decimal ObtenerPrecio(Mascota mascota, ICalcuadorVacunas precios) // S - Deben de ir en clases independientes // O - Se puede hacer una interfaz y heredar cada opción
    {
        return precios.Calcular(mascota);
    }
}

/////////////////////////////////

public interface IServicioMensajeria
{
    void Enviar(string mensaje);
}

public class EmailService : IServicioMensajeria
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando Correo: {mensaje}");
    }
}

// Ahora podria tener mas serivicos adeams del email

public class Notificacion
{
    private readonly IServicioMensajeria cartero; // D - Depencdencia directa

    public Notificacion(IServicioMensajeria servicio) // S
    {
        cartero = servicio;
    }

    public void Notificar(Mascota mascota, decimal costo)
    {
        cartero.Enviar($"Mascota info: {mascota.Nombre} | Precio: {costo}");
    }
}

/////////////////////////////////

public class SistemaVeterinaria
{
    protected List<Mascota> mascotas = new List<Mascota>();

    // Dependencias (DIP)
    private readonly Notificacion _notificador;
    private readonly CalculadoraVacunas _calculadoraService;
    private readonly ICalcuadorVacunas _precioEstrategia;

    public SistemaVeterinaria(Notificacion notificador, CalculadoraVacunas calculadoraService, ICalcuadorVacunas precioEstrategia)
    {
        _notificador = notificador;
        _calculadoraService = calculadoraService;
        _precioEstrategia = precioEstrategia;
    }

    public virtual void AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new Mascota(nombre, tipo, edad);
        var validador = new ValidadorMascota();

        if (!validador.EsValida(mascota))
        {
            Console.WriteLine("Mascota no se puede registrar.");
            return;
        }

        mascotas.Add(mascota);

        decimal costo = _calculadoraService.ObtenerPrecio(mascota, _precioEstrategia);

        _notificador.Notificar(mascota, costo);

        Console.WriteLine("Resumen de la lista de mascotas | Reporte:");
        foreach (var m in mascotas)
        {
            Console.Write($"{m.Nombre} - {m.Tipo} ");
        }
    }
}

public class SistemaVeterinariaEspecial : SistemaVeterinaria
{
    public SistemaVeterinariaEspecial(
        Notificacion notificador,
        CalculadoraVacunas calculadoraService,
        ICalcuadorVacunas precioEstrategia)
        : base(notificador, calculadoraService, precioEstrategia)
    {
    }

    public override void AtenderMascota(string nombre, string tipo, int edad)
    {
        if (tipo == "Perro")
        {
            Console.WriteLine("[Aviso Especial]: Esta mascota es un perro, los perros no se admiten en este sistema.");
        }
        base.AtenderMascota(nombre, tipo, edad);
    }
}