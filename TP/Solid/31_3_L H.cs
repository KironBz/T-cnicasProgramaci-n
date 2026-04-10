// Sin aplicaar SLP

// Programa Principal
List<Monstruo> monstruos = new () 
{
    new Vampiro("Edward"),
    new CalabazaDecorativa("Jhon")
};

Console.WriteLine("Fiesta sin aplicar Liskov");
/*
foreach (var m in monstruos)
{
    m.Asustar();
}
*/

// Usando LSP
Console.WriteLine("Fiesta Aplicando Liskov");
List<IAsustable> asustables = new()
{
    new VampiroLSP("Edward")
};

foreach (var a in asustables)
{
    a.Asustar();
}

// Clases
public class Monstruo
{
    // Atributos y propiedades
    public string Nombre { get; set; }
    // Constructor
    public Monstruo(string nombre) => Nombre = nombre; // La asignacion de parametros si es en una linea se contra =>

    public virtual void Asustar()
    {
        Console.WriteLine($"{Nombre} intenta asustar...");
    }
}

public class Vampiro : Monstruo
{
    public Vampiro(string nombre) : base(nombre) { }
    public override void Asustar()
    {
        Console.WriteLine($"{Nombre}: Se transforma en murcielago");
    }
}

public class CalabazaDecorativa : Monstruo
{
    public CalabazaDecorativa(string nombre) : base(nombre) { }
    public override void Asustar()
    {
        // Esta clase no deberia asustar
        throw new NotImplementedException("Las Calabazas Decorativas No Pueden Asustar");
    }
}

// Aplicando LSP
public abstract class MonstruoLSP
{ 
    public string Nombre { get; set;}
    public MonstruoLSP(string nombre)
    {
        Nombre = nombre;
    }
} 

public interface IAsustable
{
    void Asustar();
}

class VampiroLSP : MonstruoLSP, IAsustable 
{
    public VampiroLSP(string nombre) : base(nombre) { }
    public void Asustar()
    {
        Console.WriteLine($"{Nombre}: Se transforma en murcielago, bu te asusto te asusto");
    }
}

class CalabazaDecorativaLSP : MonstruoLSP
{
    public CalabazaDecorativaLSP(string nombre) : base(nombre) { }
    public void Brillar() => Console.WriteLine($"{Nombre}: Brilla y brilla tan linfo y brillamos juntos, por la eternidaaad");
}