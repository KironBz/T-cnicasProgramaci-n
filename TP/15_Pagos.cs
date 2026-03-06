// Programa Principal

// Cambio para git

/*
string numero = "1234567";
Console.WriteLine(numero.Length);
*/

bool continua = true;
List <IPago> list = new List <IPago> ();
do
{
    Console.WriteLine("Ingresa El Monto A Pagar");
    
}
while (continua);

// Interfaz y clases

public interface IPago
{
    void ProcesarPago();
}

// Clase de pago en efectivo

public class PagoEfectivo : IPago
{
    // Atributos
    public double Monto { get; set; }

    // Constructor
    public PagoEfectivo(double monto)
    {
        Monto = monto;
    }

    //Metodos
    public void ProcesarPago()
    {
        Console.WriteLine($"Pago En Efectivo De ${Monto} Procesado");
    }
}

public class PagoTarjeta : IPago
{
    // Atributos
    public string NumeroTarjeta { get; set; }
    public double Monto { get; set; }

    // Constructor
    public PagoTarjeta(string numeroTarjeta, double monto)
    {
        NumeroTarjeta = numeroTarjeta;
        Monto = monto;
    }

    //Metodos
    public void ProcesarPago()
    {
        if (NumeroTarjeta.Length == 16)
        {
            Console.WriteLine($"Pago Con Tarjeta De ${Monto} Procesado");
        }
        else
        {
            Console.WriteLine($"Tarjeta Invalida");
        }
    }
}