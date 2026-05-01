// Manejo de Archivos
/* Libreria en especifico*/
using System.IO;

// Escritura /*09:42; 39:00*/

// Ruta Relaitva
/* Posicion actual es el . */
string ruta = "./archivo.txt";

// Ruta Absoluta
/*Toda la cadena de la ruta, despues \ y nombre de la ruta, aqui estara bien en casa no creo por la ruta*/
string ruta2 = @"C:\Users\Alumnos\Documents\Bohorquez Hunab\archivo2.txt";

using (StreamWriter writer = new StreamWriter(ruta))
{
    /* C:\Users\Alumnos\Documents\Bohorquez Hunab\TP\bin\Debug\net8.0 ahi esta
     Si se vuelve a ejecutar se sobreescribe */
    writer.WriteLine("Hola, este es un archivo de texto"); 
    writer.WriteLine("Esta es una segunda linea"); 
}

using (StreamWriter writer = new StreamWriter(ruta2))
{
    writer.WriteLine("Hola, este es el segundo archivo de texto");
    writer.WriteLine("Esta es su segunda linea");
}

// Lectura
using (StreamReader reader = new StreamReader(ruta) )
{
    /*si quieres que lea todo es*/
    string contenido = reader.ReadToEnd();
    // string contenido = reader.ReadLine();
    Console.WriteLine(contenido);
}


// Archivo binario escritura
string rutaB = @"C:\Users\Alumnos\Documents\Bohorquez Hunab\datosBinarios.bin";

using (BinaryWriter writer = new BinaryWriter(File.Open(rutaB, FileMode.Create)))
{
    writer.Write(25);
    writer.Write(3.1416);
    writer.Write("Texto binario");
}
Console.WriteLine("Archivo binario escrito\n\n");

// Lectura del archivo binario
using (BinaryReader reader = new BinaryReader(File.Open(rutaB, FileMode.Open)))
{
    int numero = reader.ReadInt32();
    double numeroDecimal = reader.ReadDouble();
    string texto = reader.ReadString();
    
    Console.WriteLine(numero);
    Console.WriteLine(numeroDecimal);
    Console.WriteLine(texto);
}


// Acceso secuencial /*de la primera linea a la ultima*/
string rutaSecuencial = @"C:\Users\Alumnos\Documents\Bohorquez Hunab\Secuencial.txt";

using (StreamWriter writer = new StreamWriter(rutaSecuencial))
{
    /* la linea sera la primer unidad (1), no el 0 como en otros casos */
    for (int i=1; i <= 200; i++)
    {
        writer.WriteLine($"Linea {i}");
    }
}

using (StreamReader reader = new StreamReader(rutaSecuencial))
{
    string lineaLectura;
    while ((lineaLectura = reader.ReadLine()) !null)
    {
        if (lineaLectura == "Linea 150")
        {
            Console.WriteLine(lineaLectura);
        }
        // Console.WriteLine(LineaLectura);)
    }
}

// Acceso Aleatorio /* Este ya no lo entendi */
string rutaAleatoria = @"C:\Users\Alumnos\Documents\Bohorquez Hunab\Aleatorio.txt";

using (FileStream fs = new FileStream(rutaAleatoria, FileMode.Create, FileAccess.ReadWrite))
{
    using (StreamWriter writer = new StreamWriter(fs))
    {
        writer.WriteLine($"Linea 1: Hola Mundo");
        writer.WriteLine($"Linea 2: C# Blah blah blah");
        writer.WriteLine($"Linea 2: Adios Mundo");
    }

}

using (FileStream fs = new FileStream(rutaAleatoria, FileMode.Open, FileAccess.ReadWrite))
{
    //13, 3, 23 /* Es por caracter no por linea*/
    fs.Seek(23, SeekOrigin.Begin);


    using (StreamReader reader = new StreamReader(fs))
    {
        string lineaLectura = reader.ReadLine();
        Console.WriteLine("Lectura aleatoria en el punto 13:" + lineaLectura);
    }
}