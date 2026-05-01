using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

Inventario inventario = new Inventario();
bool salir = false;

while (!salir)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu De Suministros");
        Console.WriteLine("1) Mostrar Suministros");
        Console.WriteLine("2) Buscar Suministro");
        Console.WriteLine("3) Ordenar Suministro Por Nombre");
        Console.WriteLine("4) Invertir Orden");
        Console.WriteLine("5) Vaciar Inventario");
        Console.WriteLine("6) Agregar Suministro");
        Console.WriteLine("7) Eliminar Suministro");
        Console.WriteLine("8) Salir");

        Console.WriteLine("Selecciona La Operacion:");
        Console.ForegroundColor = ConsoleColor.DarkYellow;    

        int opcion = int.Parse(Console.ReadLine() ?? "");

        switch (opcion)
        {
            case 1:
                inventario.MostrarSuministros();
                break;

            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Ingresa El Nombre Del Suministro A Buscar: ");
                string nombre = Console.ReadLine() ?? "";
                inventario.buscarSuministro(nombre);
                break;

            case 3:
                inventario.ordenarPorNombre();
                break;

            case 4:
                inventario.invertirOrden();
                break;

            case 5:
                inventario.vaciarInventario();
                break;

            case 6:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Ingresa El Nombre Del Suministro A Agregar: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string nombreSum = Console.ReadLine() ?? "";

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Cantidad O Vacio ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string cantidad = Console.ReadLine() ?? "";

                if (cantidad != "")
                {
                    int cantidadValida;
                    while (true)
                    {
                        try
                        {
                            if (!int.TryParse(cantidad, out cantidadValida))
                            {
                                throw new FormatException("Debes Ingresar Un Número Válido");
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            cantidad = Console.ReadLine() ?? "";
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Prioridad (1-3)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string prioridad = Console.ReadLine() ?? "";
                    
                    int prioridadValida;
                    while (true)
                    {
                        try
                        {
                            if (!int.TryParse(prioridad, out prioridadValida) || prioridadValida < 1 || prioridadValida > 3)
                            {
                                throw new FormatException("Debes Ingresar Un Número Del 1 al 3");
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            prioridad = Console.ReadLine() ?? "";
                        }
                    }

                    inventario.agregarSuministro(nombreSum, int.Parse(cantidad), int.Parse(prioridad)); //Antes
                }
                else
                {
                    inventario.agregarSuministro(nombreSum);
                }
                break;

            case 7:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ingresa El Nombre Del Suministro A Eliminar: ");
                string nombreElim = Console.ReadLine() ?? "";
                inventario.eliminarSuministro(nombreElim);
                break;

            case 8:
            Console.ForegroundColor = ConsoleColor.White;
            salir = true;
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Opcion No Válida\n");
                break;
        }
    }
    catch (FormatException)
    {
        Console.ForegroundColor= ConsoleColor.DarkRed;
        Console.WriteLine("Debes Ingresar un número\n");
    }
    catch (algocadenaExcepcion ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: {ex.Message}\n");
    }

}

// Excepciones (2) cadena vacia y de numero a texto
class algocadenaExcepcion : Exception
{
    public algocadenaExcepcion(string mensaje) : base(mensaje) { }
    //system argument exception
}
/*class numerotextoExcepcion : Exception
{
    public numerotextoExcepcion(string mensaje) : base(mensaje) { }
    //Systemformatexception
}*/

// Clases
public class Suministro // Unidad
{
    // Atributos y Propiedades 
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public int Prioridad { get; set; } //  Debe tener 1= Alta ; 2 = Media ; 3 = Baja;

    // Constructor ¿1?
    public Suministro (string nombre, int cantidad, int prioridad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        Prioridad = prioridad;
    }


    // SobreCarga Constructor  (2)
    public Suministro(string nombre)
    {
        Nombre = nombre;
        Cantidad = 1;
        Prioridad = 2;
    }

    // Metodos
    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre} \nCantidad: {Cantidad} \nPrioridad: {Prioridad}\n");
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

        if (suministros[0] == null || suministros.Length == 0)
        {
            throw new algocadenaExcepcion("El inventario está vacio");
        }

        foreach (Suministro suministro in suministros)
        {
            if (suministro != null)
            {
                suministro.MostrarInfo();
                //Console.WriteLine($"{suministro.Nombre}"); // de 2 jalas el metodo que trae todo, o se arma a mano
            }
        }
    }

    public void buscarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower()); //s tal que del suministro s
        Console.ForegroundColor = ConsoleColor.Blue;

        if (indice >= 0)
        {
            Console.WriteLine($"{nombre} se encontro en la posicion {indice}\n");
        }
        else
        {
            Console.WriteLine($"{nombre} no se encontro en el inventario\n");
        }
    }

    public void ordenarPorNombre()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Array.Sort(suministros,(x,y) => x.Nombre.CompareTo(y.Nombre));
        Console.WriteLine("Suministros Ordenados por nombre\n");
    }

    public void invertirOrden()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Array.Reverse(suministros);
        Console.WriteLine("Orden Invertido\n");
    }

    public void vaciarInventario()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Array.Clear(suministros, 0, suministros.Length);
        Console.WriteLine($"Inventario borrado: {suministros.Length}\n");
    }

    // Agregar Suministro
    public void agregarSuministro(string nombre, int cantidad, int prioridad)
    {
        int indiceNull = Array.FindIndex(suministros, s => s == null);
        if(indiceNull >= 0)
        {
            suministros[indiceNull] = new Suministro(nombre, cantidad, prioridad);
        }
        else
        {
            Array.Resize(ref suministros, suministros.Length+1); // ref para no eliminar el arreglo y tener la longitud antes de cambiarla
            suministros[suministros.Length - 1] = new Suministro(nombre, cantidad, prioridad); //-1 para olvidar el indice 
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{nombre} agregado al inventario\n");
    }

    // Sobrecarga del metodo suministro con solo un parametro
    public void agregarSuministro(string nombre)
    {
        agregarSuministro(nombre, 1, 2); // Con recursividad, llamarse a si mismo, mandas a llamar y lo rellenas por defecto
    }

    // ELiminar suinistros
    public void eliminarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower()); //s tal que del suministro s
        if(indice >= 0)
        {
            for (int i = indice; i < suministros.Length-1; i++) 
            {
                suministros[i] = suministros[i + 1]; 
            }
            Array.Resize(ref suministros, suministros.Length - 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{nombre} eliminado del inventario\n");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{nombre} no encontrado\n");
        }
    }

}
