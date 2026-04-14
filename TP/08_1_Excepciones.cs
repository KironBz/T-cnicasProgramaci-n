// Programa Para ver Ecxepciones (son clases las excepciones)

int divisor = 0 ;
//int resultado = 10 / divisor ; se hace en el try
try
{
int resultado = 10 / divisor; // divisor o 5
}
catch (DivideByZeroException ex) //clase y nombre
{
Console.WriteLine(ex.Message);
Console.WriteLine("No se puede dividir / elige otro numero");
}
finally // este bloque siempre se ejecuta
{
Console.WriteLine("siemre se ejecuta");
}

try
{
    Console.WriteLine("Introduce un número entero postivo");
    int numero = int.Parse(Console.ReadLine() ?? "");
    if (numero < 0) //excepcion manual
    {
        throw new ArgumentException("El numero no puede ser negativo"); //se instancia como un nuevo objeto de la clase
    }
}
catch (FormatException ex) // excepcion por fomrato
{
    Console.WriteLine("Escribiste algo que no es un número");
}
catch (Exception ex) // es como un comodin para atarpar excepciones de forma general
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Siempre se Ejecuta");
}