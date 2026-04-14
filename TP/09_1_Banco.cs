 // PRograma Principal Del Banco
Banco banco = new Banco();

char repetir 'n';
do
{
    try
    {
        CuentaBancaria cuentaOrigen = banco.BuscarCuenta("123456");
        CuentaBancaria cuentaDestino = banco.BuscarCuenta("789456");

        // Transferencia
        Console.WriteLine("Haciendo Transferencia");
        Console.WriteLine($"Saldo Inicial: ${cuentaOrigen.Saldo}");
        cuentaOrigen.Transferir(cuentaDestino, 5); // si cambias 5 por algo arriva de 6 manda la excepcion
        Console.WriteLine($"Saldo Inicial: ${cuentaOrigen.Saldo}");
    



    }
    catch (CuentaNoEncontradaException ex)
    {
        Console.WriteLine(ex.Message);
        // Console.WriteLine(ex.ToString()); // Te arroja el string directo
    }
    catch (SaldoInsuficienteException ex)
    {
        Console.WriteLine(ex.Message);
        // Console.WriteLine(ex.ToString()); // Te arroja el string directo
    }
}


// Excepciones
class SaldoInsuficienteException : Exception
{
    // Solo se modifica el constructor en la herencia
    public SaldoInsuficienteException(string mensaje) : base(mensaje) { }
}

class CuentaNoEncontradaException : Exception
{
    // Solo se modifica el constructor en la herencia
    public CuentaNoEncontradaException(string mensaje) : base(mensaje) { }
}

class DepositoInvalidoException : Exception
{
    // Solo se modifica el constructor en la herencia
    public DepositoInvalidoException(string mensaje) : base(mensaje) { }
}

// Clses del Banco
public class CuentaBancaria
{
    // Atributos
    public string NumeroCuenta { get; } //No lleva el set para que no sea moficable despues de ser creado
    public decimal Saldo {  get; set; }

    // Construcotor
    public CuentaBancaria(string numeroCuenta, decimal saldo)
    {
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
    }

    // Metodos
    public void Depositar(decimal cantidad)
    {
        if(cantidad < 0)
        {
            throw new DepositoInvalidoException("No Puedes Depositar Cantidades Negativas");
        }
        Saldo += cantidad; // += hace lo mismo que  saldo = saldo + cantidad
    }

    public void Retirar(decimal cantidad)
    {
        if (cantidad > Saldo)
        {
            throw new SaldoInsuficienteException("Saldo Insuficiente Para La Operación");
        }
        Saldo -= cantidad; // -= hace lo mismo que  saldo = saldo - cantidad
    }
    public void Transferir(CuentaBancaria destino, decimal cantidad)
    {
        if (destino == null)
        {
            throw new CuentaNoEncontradaException("Cuenta No Encontrada");
        }
        Retirar(cantidad); // SE retira de la propia cuenta
        destino.Depositar(cantidad); // Se llama a la cuenta de destino y se ejecuta el depositar bajo el mismo monto
    }
}

public class Banco
{
    // Atributos
    private CuentaBancaria[] cuentas; 

    // Contructor 
    public Banco()
    {
        cuentas = new CuentaBancaria[] // Lo de abajo es el arreglo
        {
            new CuentaBancaria("123456", 6),
            new CuentaBancaria("789456", 20),
            new CuentaBancaria("741852", 10000),
        };
    }

    // Metodos
    public CuentaBancaria BuscarCuenta(string numeroCuenta)
    {
        foreach(CuentaBancaria cuenta in cuentas)
        {
            if (cuenta.NumeroCuenta == numeroCuenta)
            {
                return cuenta;
            }
        }
        throw new CuentaNoEncontradaException("Cuenta No Encontrada");
    }
}
