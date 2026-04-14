/* Programa Principal con instrucciones de nivel superior 
 * (solo un archivo de codigo puede tener instrucciones de nivel superior, que esten feura de una calse
*/

using System.Reflection;
using System.Runtime.Intrinsics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

Auto auto1 = new Auto(); // SIn el cosntructor solo lo instancias y despues entras a los atributos

auto1.Marca = "Honda";
auto1.Modelo = "Civic";
auto1.VelocidadActual = -6.3f;

Console.WriteLine($"La marca del auto es: {auto1.Marca}"); //Se imprime sin nada si no le das valores a los atributos
auto1.Acelerar(10.0f);
Console.WriteLine($"La velocidad es: {auto1.VelocidadActual}");
auto1.Frenar(100.0f);
Console.WriteLine($"La velocidad es: {auto1.VelocidadActual}");

// Herencias
Console.WriteLine("\n--- Pruebas con Herencia ---");

AutoH autoH = new AutoH("Ford", "Mustang");
Motocicleta moto = new Motocicleta("Yamaha", "MT07");

autoH.Acelerar(50f);
moto.Acelerar(60f);

moto.Frenar(70f);

// Aplica sobrecarga de operadores

if (autoH > moto )
{
    Console.WriteLine($"Auto mas rapido: {autoH.VelocidadActual}");
}
else if (autoH < moto)
{
    Console.WriteLine($"Moto mas rapido: {moto.VelocidadActual}");
}
else if (autoH == moto)
{
    Console.WriteLine("Van a la misma velodicad");
}

Console.WriteLine($"Auto: {autoH.VelocidadActual}");
Console.WriteLine($"Moto: {moto.VelocidadActual}");


// CLASES

public class Vehiculo
{
    // Atriubtos
    protected string marca;       //Nombre del atributo ; Protected le da control a la clase y a los hijos
    protected string modelo;
    protected float velocidadActual;

    // Atrubutos Publicos Con Control
    public virtual string Marca // Nombre de la funcion
    {
        get { return marca; }// Nombre del atributo
        set { marca = value; } // El value dice que la marca asignara algo a la derecha que seria la funcion MAarca
    }

    public string Modelo // Nombre de la funcion
    {
        get { return modelo; } // Nombre del atributo
        set { modelo = value; }
    }


    public float VelocidadActual // Nombre de la funcion
    {
        get { return velocidadActual; } // Nombre del atributo
        set
        {
            if (value < 0)
            {
                velocidadActual = 0;
            }
            else
            {
                velocidadActual = value;
            }
        }

    }

    // Constructor
    public Vehiculo(string marca,string modelo)
    {
        this.marca = marca; //this la instancia del objeto tendra el valor del parametro marca autox/motox tendra el parametro de ese valor
        this.modelo = modelo;
        this.velocidadActual = 0f; //0.0f
    }


    //Metodos
    public void Acelerar(float incremento)
    {
        VelocidadActual += incremento;
    }

    public void Frenar(float decremento) => VelocidadActual -= decremento;

    // Sobrecarga de los operadores > < == para comparar velocidad
        // si sobrecargas > sobrecargas tambien <
    public static bool operator >(Vehiculo v1, Vehiculo v2)
    {
        return v1.velocidadActual > v2.velocidadActual;
    }
    public static bool operator <(Vehiculo v1, Vehiculo v2)
    {
        return v1.velocidadActual < v2.velocidadActual;
    }

        // Al sobrecargar == también se debe sobrecargar != y Equals()
    public static bool operator ==(Vehiculo v1, Vehiculo v2)
    {
    return v1.velocidadActual == v2.velocidadActual;
    }
    public static bool operator !=(Vehiculo v1, Vehiculo v2)
    {
        return v1.velocidadActual != v2.velocidadActual;
    }
}

public class AutoH : Vehiculo
{
    public AutoH(string marca, string modelo) : base(marca, modelo)  { }

    // Campo
    //Constructor
    // Metodos
    public override string Marca // NOmbre de la funcion
    {
        get
        {
            Console.WriteLine($"La marca del auto es: {marca}");
            return marca;
        }
        set { marca = value; }
    }
}

public class Motocicleta : Vehiculo
{
    //Constructor
    public Motocicleta(string marca, string modelo) : base(marca, modelo) { }
}

public class Auto
{
    // Atriubtos
    private string marca;       //Nombre del atributo
    private string modelo;
    private float velocidadActual;

    // Atrubutos Publicos Con Control
    public string Marca // NOmbre de la funcion
    {
        get { return marca; }// NOmbre del atributo
        set { marca = value; } // El value dice que la marca asignara algo a la derecha que seria la funcion MAarca
    }

    public string Modelo { get => modelo; set => modelo = value; } //es lo mismo pero condensado

    public float VelocidadActual // NOmbre de la funcion
    {
        get => velocidadActual;  // NOmbre del atributo
        set //=> velocidadActual = value < 0 ? 0 : value; otra opcion valida
        {
            if (value < 0)
            {
                velocidadActual = 0;
            }
            else
            {
                velocidadActual = value;
            }
        }

    }

    // Constructor, puede ser opcional, se puede crear una clase sin consturctor


    //Metodos
    public void Acelerar(float incremento)
    {
        VelocidadActual += incremento;
    }

    public void Frenar(float decremento) => velocidadActual -= decremento;
}