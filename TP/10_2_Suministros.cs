
public class Suministro // Unidad
{
    // Atributos y Propiedades 
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public int Prioridad { get; set; } //  DEbe tener 1= Alta ; 2 = Media ; 3 = Baja;

    // Constructor ¿1?
    public Suministro (string nombre, int cantidad, int prioridad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        Prioridad = prioridad;
    }


    // SobreCarga Constructor 
    public Suministro(string nombre)
    {
        Nombre = nombre;
        Cantidad = 1;
        Prioridad = 2;
    }

    // Metodos
    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre} \nCantidad: {Cantidad} \n Prioridad: {Prioridad}");
    }
}

public class Inventario // Tiene suministros
{
    // Atributos y Propiedades
    private Suministro[] suministros;

    // Constructor
    public Inventario()
    {
        suministros = new Suministro[] 
        {
            new Suministro("Oxigeno", 15, 1),
            new Suministro("Gasolina"),
            new Suministro("Comida", 30, 1),
            new Suministro("Almohada", 15, 3),
            new Suministro("Botiquin", 4, 1),
            new Suministro("Herramientas"),
        };
    }

    // Metodos
    public void MostrarSuministros()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Inventario De Suministros");
        Console.ForegroundColor = ConsoleColor.Blue;

        foreach(Suministro suministro in suministros)
        {
            Console.WriteLine($"{suministro.MostrarInfo}");
            // Console.WriteLine($"{suministro.Nombre}"); // de 2 jalas el metodo que trae todo, o se arma a mano
        }

    }

}
