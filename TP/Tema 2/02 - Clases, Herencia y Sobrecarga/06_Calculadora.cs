#region Calculadora Pt1

/*

// Programa principal
Calculadora calculadora = new Calculadora(5, 2);

Console.WriteLine($"Los numeros a operar son: \nNumero 1 = {calculadora.Numero1} \nNumero 2 = {calculadora.Numero2} \n");

int resultado = calculadora.Suma();
Console.WriteLine($"El resultado de la suma es: {resultado}");

resultado = calculadora.Resta();
Console.WriteLine($"El resultado de la resta es: {resultado}");

resultado = calculadora.Multiplicacion();
Console.WriteLine($"El resultado de la multiplicacion es: {resultado}");

float resultadoD = calculadora.Division();
Console.WriteLine($"El resultado de la division es: {resultadoD}");

// Clases
    // Calculadora basica que opera solo 2 numeros enteros
public class Calculadora
{
    // Atributos publicos (Propiedades)
    public int Numero1 { get; set; } // Encapsulamiento
    public int Numero2 { get; set; }

    // Constructor 
    public Calculadora (int numero1, int numero2)
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }

    // Metodos
    public int Suma()
    {
        return Numero1 + Numero2;
    }

    public int Resta()
    {
        return Numero1 - Numero2;
    }

    public int Multiplicacion()
    {
        return Numero1 * Numero2;
    }
    public float Division()
    {
        if (Numero2==0)
        {
            Console.WriteLine("MATH ERROR");
            return 0;
        }
        return (float) Numero1 / Numero2;
    }
}

*/

#endregion

#region Calculadora Avanzada
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Ingresa el primer número a operar");
int num1 = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("Ingresa el segundo número a operar");
int num2 = int.Parse(Console.ReadLine() ?? "");

// Opcional
// Console.Clear();
// XD

Console.WriteLine("\nCalculadora a usar \n1) Básica \n2) Científica");
int sel = int.Parse(Console.ReadLine() ?? "");

if (sel == 1)
{
    Calculadora calculadora1 = new Calculadora(num1, num2);
    Console.WriteLine("\nElige una operación \n1- Suma \n2- Resta\n3- Multiplicacion \n4- Division");
    sel = int.Parse(Console.ReadLine() ?? "");

    switch (sel)
    {
        case 1:
            Console.WriteLine($"\nEl resultado de la calculadora básica : {calculadora1.Suma()}");
            break;
        case 2:
            Console.WriteLine($"\nEl resultado de la calculadora básica : {calculadora1.Resta()}");
            break;
        case 3:
            Console.WriteLine($"\nEl resultado de la calculadora básica : {calculadora1.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"\nEl resultado de la calculadora básica : {calculadora1.Division()}");
            break;
        default: // <--- ¡Aquí van dos puntos, no punto y coma!
            Console.WriteLine("\nOpción no válida");
            break;
    }
}
else if (sel== 2)
{
    CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica(num1, num2);
    Console.WriteLine("\n1- Suma \n2- Resta\n3- Multiplicacion \n4- Division" +
        "\n5- Logaritmo\n6- Raiz Cuadrada \n7- Factorial");
    sel = int.Parse(Console.ReadLine() ?? "");

    switch (sel)
    {
        case 1:
            Console.WriteLine($"\nEl resultado de la calculadora cientifica : {calculadoraCientifica.Suma()}"); //será el cuadrado de la suma
            break;
        case 2:
            Console.WriteLine($"\nEl resultado de la calculadora cientifica : {calculadoraCientifica.Resta()}");
            break;
        case 3:
            Console.WriteLine($"\nEl resultado de la calculadora cientifica : {calculadoraCientifica.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"\nEl resultado de la calculadora cientifica : {calculadoraCientifica.Division()}");
            break;
        case 5:
            Console.WriteLine($"\nEl resultado de la calculadora cientifica : {calculadoraCientifica.Logaritmo()}");
            break;
        case 6:
            Console.WriteLine($"\nEl resultado de la calculadora cientifica : {calculadoraCientifica.RaizCuadrada()}");
            break;
        case 7:
            Console.WriteLine($"\nEl resultado de la calculadora cientifica : {calculadoraCientifica.Factorial()}");
            break;

        default: // <--- ¡Aquí van dos puntos, no punto y coma!
            Console.WriteLine("\nOpción no válida");
            break;
    }
}




// Clases
// Calculadora Básica
public class Calculadora
{
    // Atributos Públicos y Propiedades
    public int Numero1 { get; set; }
    public int Numero2 { get; set; }

    // Atributo Privado
    private int Resultado;
    private string mensaje = "AsdfgAsdfg"; // No se para que esta

    // Consctructor
    public Calculadora(int numero1, int numero2)
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }

    // Metodos
    public virtual int Suma() //el Virtual permite hacer override, modificacion en una clase hija
    {
        Resultado = Numero1 + Numero2;
        return Resultado;
    }

    private void MostrarMensaje() // Metodo privado, no se porque esta
    {
        Console.WriteLine(mensaje);
    }

    protected void Mensaje() // Metodo protegido, no se porque esta
    {
        MostrarMensaje();
    }

    public virtual int Suma(int num3) // Sobrecarga del metodo Suma
    {
        return Numero1 + Numero2 + num3;
    }

    public int Resta()
    {
        return Numero1 - Numero2;
    }
    public int Multiplicacion()
    {
        return Numero1 * Numero2; 
    }

    public float Division()
    {
        if (Numero1 == 0)
        {
            Console.WriteLine("Math Error");
            return 0;
        }
        return (float) Numero1 / Numero2; // Casteo, float trasnfoma a decimal a Numero1 y despues la misma contagia a toda la operacion
    }

    // Sobrecarga del operador +
    public static Calculadora operator +(Calculadora calc1, Calculadora calc2)
    {
        return new Calculadora(calc1.Numero1 + calc1.Numero1, calc1.Numero2 + calc1.Numero2);
    }
}

    // Clase Hija
public class CalculadoraCientifica : Calculadora
{
    // Atributos y Propiedades (No hay porque fueron heredadas

    // Constructor
    public CalculadoraCientifica(int num1, int num2) : base(num1, num2)
    {

    }

    // Metodos
    public double Logaritmo()
    { 
        return MathF.Log(Numero1); 
    }

    public double RaizCuadrada()
    {
        return MathF.Sqrt(Numero2);
    }

    // Override Cambia el metodo geredado
    public override int Suma()
    {
        int resultado = base.Suma();
        return resultado * resultado;
    }

    public void MensajeC()
    {
        base.Mensaje();
    }

    public int Factorial()
    {
        if (Numero1 == 0 || Numero2 == 1) // Barra vertical alt 124 ||
        {
            return 1;
        }
        else if (Numero1<0)
        {
            Console.WriteLine("No existe el facotrial de un numero negativo");
            return 0;
        }
        else
        {
            int Fct = 1;
            for (int i = 2; i <= Numero1; i++)
            {
                Fct = Fct * i;
            }
            return Fct;
        }
    }
}

#endregion