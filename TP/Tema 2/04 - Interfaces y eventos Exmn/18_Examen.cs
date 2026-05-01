// Bohorquez Lopez Hunab Ku Abdala

// Programa Principal


// Clases
using System.Security.Cryptography.X509Certificates;

public abstract class Bola
{
    // Atributos Y Propiedades
    protected double Masa { get; }
    protected double PosX { get; }
    protected double PosY { get; }

    // Variables de clase  ////////////////////////////////////////////

    // Constructor
    public Bola (double masa)
    {
        Masa = masa;
        PosX = 0;
        PosY = 0;
    }

    // Metodos
    public void Mover(double nposX, double nposY) // llevara void?
    {
        double posX = PosX;
        double posY = PosX;
        double Dx = posX + nposX;
        double Dy = posY + nposY;

    }
    public abstract double Friccion(); // ASDFGASFDG
}

public class BolaNormal : Bola
{
    // Constructor
    public BolaNormal(double masa) : base(masa) {  }
    public override double Friccion()
    {
        return 1.2;
    }
}

public class BolaProfesional : Bola
{
    // Constructor
    public BolaProfesional(double masa) : base(masa) { }
    public override double Friccion()
    {
        return 0.6;
    }
}

public class Tiro
{
    // Atributos y Propiedades
    private double Impulso { get; }
    private double DirX { get; }
    private double DirY {  get; }

    // Constructor
    public Tiro(double impulso, double dirX, double dirY)
    {
        Impulso = impulso;
        DirX = dirX;
        DirY = dirY;
    }

    // Metodos

}

public interface IEstrategiaCalculo /////// NOPE ////////////////////////////////////////////
{
    double CalcularDistancia(double impulso, double masa, double mu);
}

public class CalculoFisica : IEstrategiaCalculo
{
    public double CalcularDistancia(double I, double m, double mu)
    {
        double g = 9.81;
        double v0 = I / m;
        double a = -(mu * m * g) / m;
        return -(Math.Pow(v0, 2)) / (2 * a);
    }
}

public class CalculoSimple : IEstrategiaCalculo
{
    public double CalcularDistancia(double I, double m, double mu) => I / (m * mu);
}


public class SimuladorBillar
{
    // Atributos  Y Propiedaeds
    private Bola _bola;
    private List<Tiro> _tiros = new List<Tiro>();
    private IEstrategiaCalculo _estrategia = new CalculoFisica();
    private double _distanciaTotal = 0;

    // Constructor
    // Metodos
    public void CrearBola(string tipo, double masaGramos)
    {
        double masaKg = masaGramos / 1000.0;
        if (tipo == "NORMAL") _bola = new BolaNormal(masaKg);
        else _bola = new BolaProfesional(masaKg);
    }

    public void RegistrarTiro(double imp, double x, double y) => _tiros.Add(new Tiro(imp, x, y));

    public void CambiarEstrategia(IEstrategiaCalculo nuevaEstrategia) => _estrategia = nuevaEstrategia

    public void Simular()
    {
        _distanciaTotal = 0;
        foreach (var tiro in _tiros)
        {
            double d = _estrategia.CalcularDistancia( /*ASDFGASDFG*/);
            _distanciaTotal += d;

            
        }
    }

    public void Resultado()
    {

    }
}