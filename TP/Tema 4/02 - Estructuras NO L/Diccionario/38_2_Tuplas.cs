// TUPLA
// No son estructuras,, son una forma de agrupar datos heterogeneos
// Tamaño fijo
// Inmutable
// Limite de elementos 8


// Tupla sin nombres
(string, int) persona1 = ("Ana", 25);
//(string, int, bool, int[] ) hasta8 = ("Asdfg", 5, true, );

// Tupla con nombres
(string Nombre, int Edad) persona2 = ("Juan", 30);

// Acceso a elementos
Console.WriteLine(persona1.Item2);
Console.WriteLine(persona2.Nombre);

// Devolver tupla en metodo
static (int, int) Dividir(int dividendo, int divisor)
{
    return (dividendo / divisor, dividendo % divisor);
}
var resultado = Dividir(10, 3);

Console.WriteLine($"Conciente: {resultado.Item1}, Modulo: {resultado.Item2}");














