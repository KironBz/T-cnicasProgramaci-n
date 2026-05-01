
#region 09/02/2026
//Programa de forma secuencial

using System.IO.Pipes;

Console.WriteLine("Ingresa El Nombre: ");
string nombre = Console.ReadLine() ?? "";

Console.WriteLine("Ingresa La Edad: ");
int edad = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine($"\nNombre: {nombre}"); //IA \n
Console.WriteLine($"Edad: {edad}");
#endregion

// Programa orienado a objetos
Persona humano1 = new Persona(nombre, edad, "España"); //instancia un nuevo objeto de tipo persona

/*
Console.WriteLine($"Nombre  Objeto: {humano1.Nombre}");
Console.WriteLine($"Nombre  Objeto: {humano1.Edad}");
*/

humano1.MostrarDatos();
Persona.MostrarPais();

Persona humano2 = new Persona("Angel", 22, "Costa Rica");
humano2.MostrarDatos();
Persona.MostrarPais();
