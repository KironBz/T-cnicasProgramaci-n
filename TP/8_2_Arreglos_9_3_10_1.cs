/* Arreglos con [] arreglos son objetos sin atributos

// Declaracion con tmaño explicito
using static System.Runtime.InteropServices.JavaScript.JSType;

int [] numeros = new int[2]; //tambien es un objeto, una instancia de un arreglo de 2 numeros

// Asignando elementos al arreglo
numeros[1] = 8; // atraves del indice 0 - idk

// Obteniendo valores
if (numeros[0] == 0)
{
    Console.WriteLine("Hay un cero");
}

// Obteniendo la longitud del arreglo , declaracion explicita
Console.WriteLine(numeros.Length); //se usa el .lenght para obtener la longitud, mas no indie (0, 1);

//declaracion implicita
int[] numeros2 = new[] { 4, 5, 3, 6, 5 }; //colocas los valores adentro
Console.WriteLine(numeros2[3]); // entra por indice


char[] vocales = new[] {'a', 'e', 'i', 'o', 'u'}; //comilla individual
for (int i = 0; i < vocales.Length; i++)
{
    Console.WriteLine(vocales[i]);
}
foreach (char c in vocales) // Variante del for, ciclo repetitivo, cual es el valor inficidual y el arrelgo a contar
{
    Console.WriteLine(c);
}


bool[] estado = new bool[3]; // arreglo de booleanos

foreach (bool b in estado) // Variante del for, ciclo repetitivo, cual es el valor inficidual y elarrelgo a contar
{
    Console.WriteLine(b);
    //if (b==0) // no se aplica porque se ve como false, no 0
    if (!b) // negacion de si es falso, se pregunta si es falso o verdadero, si se quita el !, se pregunta si b es verdadero
    {
        Console.WriteLine("Idk");
    }
}



// METODOS ARREGLOS

//Ordenar arreglo
Console.WriteLine("Desordenado");
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

Array.Sort(numeros2); // Ordenamiento tipo burbuja SORT mayor a menor
Console.WriteLine("Ordenado con Sort");
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

Array.Reverse(numeros2); // Ordenamiento tipo burbuja Reverse invierte las posiciones
Console.WriteLine("Reverse");
foreach (int numero in numeros2)
{
    Console.WriteLine(numero);
}

// Metodo para buscar un valor, funciono pero creo que fallaba algo tecnico quitando el sort y el reverse
int indice = Array.BinarySearch(numeros2,6);
Console.WriteLine(indice);

//
// LISTAS 
//

Console.WriteLine("LISTA");

List <int> numeros3 = new List<int>(); // se instancia la lista, no necesita saber el numero de elementos
//Arreglos definidos, Listas dinamicas

numeros3.Add(0);
numeros3.Add(20);

foreach (int numero in numeros3)
{
    Console.WriteLine(numero);
}

// Acceder a un elemento de la lista
Console.WriteLine("añadiendo 30");
numeros3.Add(30);
int primerNumero = numeros3[0];
Console.WriteLine(primerNumero);

// Eliminar un elemento
Console.WriteLine("ELiminando");
numeros3.Remove(primerNumero);

foreach (int numero in numeros3)
{
    Console.WriteLine(numero);
}

primerNumero = numeros3[0];
Console.WriteLine(primerNumero);

// Eliminar por indice
numeros3.RemoveAt(0);
primerNumero = numeros3[0];
Console.WriteLine(primerNumero);

//
// Delclarar la lista con valores asignados
//

Console.WriteLine("NOMBRES");
List<string> nombres = new List<string> {"Ana","Luis", "Carlos"};
nombres.Add("Pablo");
Console.WriteLine(nombres.Count());

foreach (string nombre in nombres)
{
    Console.WriteLine(nombre);
}
nombres.Sort();

Console.WriteLine("Ordenando");

foreach (string nombre in nombres)
{
    Console.WriteLine(nombre);
}

nombres.Clear();
Console.WriteLine(nombres.Count());

Console.WriteLine(nombres.Contains("Carlos"));  // Devuelve verdadero o flaso dependiendo de si esta o no... clear

*/
////
/// EJERCICIO
////

List<Persona> personas = new List<Persona>();

personas.Add(new Persona("Joaquin", 20, "México")); //solo te pide la instancia, no la referencia de donde se guardara
personas.Add(new Persona("Enrique", 15, "Canada"));
personas.Add(new Persona("Elias", 8, "Colombia"));
personas.Add(new Persona("Luis", 18, "Uruguay"));
personas.Add(new Persona("Daniela", 21, "Brasil"));

// Imprimiendo Datos
foreach (Persona persona in personas)
{
    persona.MostrarDatos();
}

// personas.Sort(); // No funciona, deberia de hacerse una sobrecarga de operadores

// Filtrando >18
Console.WriteLine("\n\nMayores de 18 años:");
foreach (Persona persona in personas)
{
    if (persona.Edad >= 18)
    {
        persona.MostrarDatos();
    }
}


public class Persona
{
    // Atributos
    public string Nombre { get; set; } //Encapsulamiento
    public int Edad { get; set; }

    // Atributo static
    public string Pais { get; set; }

    // Constructro
    public Persona(string nombre, int edad, string pais)
    {
        Nombre = nombre;
        Edad = edad;
        Pais = pais;
    }

    // Metodos
    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre  Objeto: {Nombre}");
        Console.WriteLine($"Edad  Objeto: {Edad}\n");

    }
}
