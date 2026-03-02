//Ejemplo de interfaces

// Programa Principal
//IEjemplo algue = IEjemplo(); // No se puede declarar por que no tiene constructor, instancias una clase
IEjemplo algo = new EjemploClase();
algo.HacerAlgo();

// Declaracion
public interface IEjemplo
{
    // Definiion de Metodos
    void HacerAlgo();

    // Metodo con Implementacion
    public void HacerAlgoMas()
    {
        Console.WriteLine("Haceindo ALgo Mas");
    }
}

public class EjemploClase : IEjemplo
{
    public void HacerAlgo()
    {
        Console.WriteLine("Haciendo Algo");
    }
}