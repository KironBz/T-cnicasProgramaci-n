// Sistema de Vacunas En Una Veterinaria

Console.WriteLine("Caso1 mascota comun:");
var sistema = new SistemaVeterinaria();
sistema.AtenderMascota("Juanito", "Perro", 2);

Console.WriteLine();

Console.WriteLine("Caso2 mascota comun no contemplado:");
var sistema2 = new SistemaVeterinaria();
sistema2.AtenderMascota("Jorgito", "Ave", 3);

Console.WriteLine();

    Console.WriteLine("Caso3 mascota especial:");
    SistemaVeterinaria sistema3 = new SistemaVeterinariaEspecial();
    sistema3.AtenderMascota("Rex", "Perro", 8);     // NO cumple con L, el hijo debe hacer lo mismo del padre


Console.WriteLine();

Console.WriteLine("Caso4 mascota especial:");
var sistema4 = new SistemaVeterinaria();
sistema4.AtenderMascota("Bolillo", "Cocodrilo", 20);

// Clases Dominio
public class Mascota
{
    public string Nombre { get; set; } 
    public string Tipo { get; set; }
    public int Edad { get; set; }

    public Mascota(string nombre, string tipo, int edad) // S - Tambien va solito
    {
        Nombre = nombre;
        Tipo = tipo;
        Edad = edad;
    }

    public bool EsValida() // S - Deben de ir en clases independientes
    {
        return !string.IsNullOrEmpty(Nombre) && Edad > 0;
    }

    public decimal CalcularVacuna() // S - Deben de ir en clases independientes // O - Se puede hacer una interfaz y heredar cada opción
    {
        if (Tipo.StartsWith("P") ) return 200;
        if (Tipo.StartsWith("G")) return 180;
        if (Tipo.StartsWith("tuga")) return 400;

        return Edad * 50;
    }
}

public class EmailService
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando Correo: {mensaje}");
    }
}


public class Notificador
{
    private EmailService email = new EmailService();
    
    public void Notificar(Mascota mascota)
    {
        email.Enviar($"Mascota info: {mascota.Nombre} | ${mascota.CalcularVacuna() } ");
    }
}

public class SistemaVeterinaria
{
    private List<Mascota> mascotas = new List<Mascota>();
    Notificador notificador = new Notificador();

    public virtual void  AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new Mascota(nombre, tipo, edad);
            
        if (!mascota.EsValida())   // Quizas lleve la O idk
        {
            Console.WriteLine("Mascota no se puede registrar.");
            return;
        }

        mascotas.Add(mascota);
        decimal costo = mascota.CalcularVacuna();
        notificador.Notificar(mascota );

        Console.WriteLine("Resumen de la lista de mascotas | Reporte:");

        foreach ( var m in mascotas )
        {
            Console.Write( $"{m.Nombre} - {m.Tipo}" );
        }

    }
}

public class SistemaVeterinariaEspecial : SistemaVeterinaria
{
    public override void AtenderMascota(string nombre, string tipo, int edad)
    {
        if (tipo == "Perro")    // Quizas lleve la O idk

        {
            Console.WriteLine("Los perros no se atieneden en este sistema");
            throw new Exception("Sistema Incorrecto");
        }

        base.AtenderMascota(nombre, tipo, edad);
    }
}





// IDentificar las cosas, responsabilidades de clase, dependencias directas, abtraccion para interfases, sustituciones en herencia funsionan o no
    // no encontre de I, suongo que saldra 



// DEspues de comentar el archivo se crea otro archivo donde se implementen las modificaciones en el codigo

// Primer Archivo NoSolid codigo comentado; 
// Segundo Archivo Solid.cs  se deben de aplicar las sugeriencias del primer archivo con los 5 principios solid