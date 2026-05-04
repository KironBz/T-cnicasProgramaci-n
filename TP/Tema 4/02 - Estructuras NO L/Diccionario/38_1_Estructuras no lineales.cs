// FALLA ALGO REVISAR DICCIONARIO

// estructura no inea diccionario
// Cada clave es unica y tiene un valor asicado
// No mantiene un orden especifico
// No tiene orden de insercion

// Creacion

Dictionary <string, int> edades = new Dictionary<string, int>();

// Agregar elementos
edades.Add("Ana", 25);  // Método
edades.Add("Ana", 25);  // Método
edades["Maria"] = 28;   // Asignacion

// Acceso
int edadAna = edades["Ana"];
Console.WriteLine(edadAna);

// VeriFicar la existencia de clave    ¿Paso por valor y paso por referencia?
if (edades.ContainsKey("Carlos"))
{
    Console.WriteLine("Carlos existe");
}
if (edades.ContainsValue(25))
{
    Console.WriteLine("Alguien tiene 25 años");
}

// Intentar obtener el valor de una clave
if (edades.TryGetValue("Juan", out int edadJuan) )
{
    Console.WriteLine($"Edad Juan {edadJuan}");
}

// Recorrer diccionario
foreach (KeyValuePair <string, int> kvp in edades)
{
    Console.WriteLine($"{kvp.Key} {kvp.Value}");
}

foreach(string nombre in edades.Keys)
{
    Console.WriteLine(nombre);
}

foreach (int edad in edades.Values)
{
    Console.WriteLine(edad);
}

// Eliminar
edades.Remove("Ana"); // Por clave

foreach (int edad in edades.Values)
{
    Console.WriteLine(edad);
}

Dictionary<string, int[,][]> dic = new Dictionary<string, int[,][]>();















