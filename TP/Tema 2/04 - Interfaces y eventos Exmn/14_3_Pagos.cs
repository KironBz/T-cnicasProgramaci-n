// Programa Principal

using System.Diagnostics;

bool continua = true;
List <IPago> listaPagos = new List <IPago> ();
do
{
    Console.WriteLine("Ingresa El Monto A Pagar");
    string montoTexto = Console.ReadLine() ?? "";
    if (double.TryParse(montoTexto, out double monto))
    {
        string modoPagoT;
        int modoPago;
        do
        {
            Console.WriteLine("1) Pago Con Tarjeta");
            Console.WriteLine("1) Pago En Efectivo");
            modoPagoT = Console.ReadLine() ?? "";
        }
        while (!int.TryParse(modoPagoT, out modoPago) || (modoPago !=1 && modoPago !=2 )); //While repite si es verdadero
        
        if(modoPago == 1)
        {
            Console.WriteLine("Ingresa El Número De Tarjeta");
            string tarjeta = Console.ReadLine() ?? "";

            // Creando Objeto Para Pago Con Tarjeta
            IPago pago = new PagoTarjeta(tarjeta, monto);
            listaPagos.Add (pago);
        }
        else
        {
            // Creando Objeto Para Pago En EFectivo
            IPago pago = new PagoEfectivo(monto);
            listaPagos.Add(pago);
        }

    }
    else
    {
        Console.WriteLine("Error: Monto Invalido");
        return;
    }
    Console.WriteLine("Presiona S Para Procesar Más Pagos");
    char continuaT = char.Parse(Console.ReadLine() ?? "".ToLower());
    
    if (continuaT == 's')
    {
        continua = true ;
    }
    else
    {
        continua = false;
    }
}
while (continua);

foreach(IPago pago in listaPagos)
{
    pago.ProcesarPago();
}


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