using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

Inventario inventario = new Inventario();
bool salir = false;

while (!salir)
{
    /*try
    {*/
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu De Suministros");
        Console.WriteLine("1)Mostrar Suministro \n" +
            "2)Buscar Suministro \n" +
            "3)Ordenar Suministro Por Nombre \n " +
            "4)Inveritr Orden \n" +
            "5)Vaciar Inventario\n \n" +
            "6)Agregar Suministro\n" +
            "7)Eliminar Suministro\n" +
            "8)Salir");

        Console.WriteLine("\nSelecciona La Operacion:");

        int opcion = int.Parse(Console.ReadLine() ?? "");

        switch (opcion)
        {
            case 1:
                inventario.MostrarSuministros();
                break;

            case 2:
                Console.WriteLine($"Ingresa El Nombre Del SUministro A Buscar: ");
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
                Console.WriteLine($"Ingresa El Nombre Del SUministro A Buscar: ");
                string nombreSum = Console.ReadLine() ?? "";

                Console.WriteLine($"Cantidad O Vacio ");
                string cantidad = Console.ReadLine() ?? "";

                if (cantidad != "")
                {
                    Console.WriteLine($"Prioridad O Vacio ");
                    string prioridad = Console.ReadLine() ?? "";

                    inventario.agregarSuministro(nombreSum, int.Parse(cantidad), int.Parse(prioridad));
                }
                else
                {
                    inventario.agregarSuministro(nombreSum);
                }
                break;

            case 7:
                Console.WriteLine($"Ingresa El Nombre Del SUministro A Eliminar: ");
                string nombreElim = Console.ReadLine() ?? "";
                inventario.eliminarSuministro(nombreElim);
                break;

            case 8:
                salir = true;
                break;

            default: // <--- ¡Aquí van dos puntos, no punto y coma!
                Console.WriteLine("\nOpcion No Válida");
                break;
        }
    //}
    /*catch 
    {
        
    }*/
}

// Excepciones (2) no se cuales XD
class algocadenaExcepcion : Exception
{
    public algocadenaExcepcion(string mensaje) : base(mensaje) { }
    //system argument exception
}

class numerotextoExcepcion : Exception
{
    public numerotextoExcepcion(string mensaje) : base(mensaje) { }
    //Systemformatexception
}


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
            if (suministro==null)
            {
                throw new algocadenaExcepcion("La cadena está vacia");
            }
            Console.WriteLine($"{suministro.MostrarInfo}");
            // Console.WriteLine($"{suministro.Nombre}"); // de 2 jalas el metodo que trae todo, o se arma a mano
        }
    }

    public void buscarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower()); //s tal que del suministro s

        if (indice >= 0)
        {
            Console.WriteLine($"{nombre} se encontro en la posicion {indice}");
        }
        else
        {
            Console.WriteLine($"{nombre} no se encontro en el inventario");
        }
    }

    public void ordenarPorNombre()
    {
        Array.Sort(suministros,(x,y) => x.Nombre.CompareTo(y.Nombre));
        Console.WriteLine("Suministros Ordenados por nombre");
    }

    public void invertirOrden()
    {
        Array.Reverse(suministros);
        Console.WriteLine("Orden Invertido");
    }

    public void vaciarInventario()
    {
        Array.Clear(suministros, 0, suministros.Length);
        Console.WriteLine($"Inventario borrado: {suministros.Length}");
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
        Console.WriteLine($"{nombre} agregado al inventario");
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
            Console.WriteLine($"{nombre} eliminado del inventario");
        }
        else
        {
            Console.WriteLine($"{nombre} no encontrado");
        }
    }

}
