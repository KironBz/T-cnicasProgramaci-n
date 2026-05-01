// Sin ISP
interface IMonstruo
{
    void Asustar();
    void Volar();
    void LanzarHechizos();
}

class Fantasma : IMonstruo
{
    public void Asustar() => Console.WriteLine("Buhhw, te asustow, te asustow");
    public void Volar() => Console.WriteLine("Fantasma uso levitacion");
    public void LanzarHechizo() => throw new NotImplementedException("Los fantasmas no lanzan hechizos");
}

class Bruja : IMonstruo
{
    public void Asustar() => Console.WriteLine("Risa Macabra o de Cabra");
    public void Volar() => Console.WriteLine("Vuela sobre su escoba");
    public void LanzarHechizo() => Console.WriteLine("Te convierte en chocolate");
}

// Aplicamos ISL
interface IAsustador { void Asustar(); }
interface IVolador { void Volar(); }
interface IHechicero { void LanzarHechizo(); }

class FantasmaI : IAsustador, IVolador
{
    public void Asustar() => Console.WriteLine("Buhhw, te asustow, te asustow");
    public void Volar() => Console.WriteLine("Fantasma uso levitacion");
}

class BrujaI : IAsustador, IVolador, IHechicero
{
    public void Asustar() => Console.WriteLine("Risa Macabra o de Cabra");
    public void Volar() => Console.WriteLine("Vuela sobre su escoba");
    public void LanzarHechizo() => Console.WriteLine("Te convierte en chocolate");
}