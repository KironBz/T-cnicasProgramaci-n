// Implementacion del Juego
using static System.Runtime.InteropServices.JavaScript.JSType;

try
{
    Console.WriteLine("Binevenido al torneo de guerreros");
    string nombre = ObtenerNombre();

    Guerrero jugador = SeleccionarClase(nombre);
    Guerrero enemigo = GenerarEnemigo();

    Console.WriteLine($"Te Enfrentaras A: {enemigo.Nombre}");
    
    while( enemigo.Vida>0 && jugador.Vida>0 )
    {
        MostrarEstado(jugador,enemigo);
        string opcion = ObtenerOpcion();

        switch (opcion)
        {
            case "1":
                jugador.Atacar(enemigo);
                break;
            
            case "2":
                Console.WriteLine($"{jugador.Nombre} Se Defiende Y El Daño Se Reduce");
                enemigo.Atacar(jugador);
                jugador.RecibirDanio(jugador.Ataque/2);
                break;
            
            case "3":
                Console.WriteLine($"Intentando La Fusión");
                if (new Random().Next(1,100) > 50)
                {
                    jugador = jugador + enemigo;
                    Console.WriteLine($"Tus Nuevas Estadisticas: {jugador.Nombre} | {jugador.Vida} | {jugador.Ataque}");
                    enemigo.RecibirDanio(enemigo.Vida); //opcional
                }
                else
                {
                    Console.WriteLine("La Funcion Fallo Y Perdiste VIda");
                    jugador.RecibirDanio(jugador.Vida/2);
                }
                    break;
            
            default:
                throw new ArgumentException("Opción Invalida");
        }

        if (enemigo.Vida>0)
        {
            enemigo.Atacar(jugador);
        }
    }

    Console.WriteLine("¡FIN DEL COMBATE!");

    Console.WriteLine(jugador.Vida > 0 ? "Felicidades, !Ganaste!" : "Has Sido Derrotado");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Apartado de FUnciones

static string ObtenerNombre()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Ingresa Nombre Del Guerrero:");
            string nombre = Console.ReadLine() ?? "".Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El Nombre No Puede Estar Vacio");
            }
            return nombre;
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error: {ex.Message}");
        }
    }
}


static string ObtenerOpcion()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Ingresa Que Quieres Hacer:");
            string opcion = Console.ReadLine() ?? "".Trim();
            if (opcion != "1" && opcion != "2" && opcion != "3" )
            {
                throw new ArgumentException("Opcion Invalida Debes ingresar 1,2 o 3");
            }
            return opcion;
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

static Guerrero SeleccionarClase(string nombre)
{
    while (true)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Selecciona tu clase de guerrero");
            Console.WriteLine("1) Caballero" +
                "\n2) Mago" +
                "\n3) Arquero" +
                "\n4) Geerrero Sombra");

            string opcion = Console.ReadLine() ?? "";

            return opcion switch
            {
                "1" => new Caballero(nombre),
                "2" => new Mago(nombre),
                "3" => new Arquero(nombre),
                "4" => new GuerreroSombra(nombre),
                _ => throw new ArgumentException("Opcion Invalida, Intenta Nuevamente")
            };

        }
        catch (Exception ex)
        {
            Console.WriteLine( $"{ex.Message}");
        }
    }
}

static Guerrero GenerarEnemigo()
{
    string[] nombres = { "Vikingo", "Orcos", "Terminator", "Mikey Mouse", "Shreck", "Zeus", "Spriu"};
    string nombre = nombres[new Random().Next(nombres.Length)]; //Solo declaramos el valor del limite final, por el Lenght si llega al final 
    return new Guerrero(nombre, new Random().Next(150,200), new Random().Next(30, 50));
}

static void MostrarEstado(Guerrero jugador, Guerrero enemigo)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Tu Vida: {jugador.Vida}");
    Console.WriteLine($"Enemigo Vida: {enemigo.Vida}");
    Console.WriteLine("1) Atacar\n"+
                      "2) Defender\n" +
                      "3) Fusionar con el enemigo\n");
}


// Definiciones de clases

public class Guerrero
{
    //Atributos
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Ataque {  get; set; }

    // Constructor
    public Guerrero(string nombre, int vida, int ataque)
    {
        Nombre = nombre;
        Vida = vida;
        Ataque = ataque;
    }

    // Metodos
    public virtual void Atacar(Guerrero enemigo)
    {
        int danio = Ataque + new Random().Next(0,5);

        // Recibir Daño
        enemigo.RecibirDanio(danio);
        Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre} causa {danio} de daño");
    }

    public void RecibirDanio (int cantidad)
    {
        Vida = Math.Max( Vida - cantidad, 0);
    }

    // Sobrecarga del operador +
    public static Guerrero operator +(Guerrero g1, Guerrero g2)
    {
        Console.WriteLine($"{g1.Nombre} + {g2.Nombre} Se fusionan en un nuevo guerrero");
        return new Guerrero($"{g1.Nombre}--{g2.Nombre}", ( g1.Vida+g2.Vida)/2 , (g1.Ataque + g2.Ataque) / 2);
    }
}

// Clase Caballero, Arquero, GuerreoSombra
public class Caballero : Guerrero
{
    // Constructor
    public Caballero(string nombre) : base(nombre, 120, 20) {    }

    // Polimorifsmo
    public override void Atacar(Guerrero enemigo)
    {
        Console.Write($"{Nombre} (Caballero) usa golpe critico");
        base.Atacar(enemigo);
    }
}

// Clase Mago
public class Mago : Guerrero
{
    // Constructor
    public Mago(string nombre) : base(nombre, 80, 25) { }

    // Polimorifsmo
    public override void Atacar(Guerrero enemigo)
    {
        Console.Write($"{Nombre} (Mago) lanza hechizo de fuego");
        base.Atacar(enemigo);
    }
}

// Clase Arquero
public class Arquero : Guerrero
{
    // Constructor
    public Arquero(string nombre) : base(nombre, 90, 15) { }

    // Polimorifsmo
    public override void Atacar(Guerrero enemigo)
    {
        int probabilidad = new Random().Next(1, 100);
        if (probabilidad < 30)
        {
            Console.WriteLine($"{Nombre} (Arquero) Dispara una flecha y falla");
        }
        else
        {
            Console.Write($"{Nombre} (Arquero) lanza una flecha y acierta");
            base.Atacar(enemigo);
        }
    }
}

// Clase Guerrero Sombra
public class GuerreroSombra : Guerrero
{
    // Constructor
    public GuerreroSombra(string nombre) : base(nombre, 110, 22) { }

    // Polimorifsmo
    public override void Atacar(Guerrero enemigo)
    {
        int chance = new Random().Next(1, 100);
        if (chance < 20)
        {
            Console.WriteLine($"{Nombre} (Guerrrero Sombra) Desaparece");
        }
        else
        {
            Console.Write($"{Nombre} (Guerrero Sombra) ataca");
            base.Atacar(enemigo);
        }
    }
}
