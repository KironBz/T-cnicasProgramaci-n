// Programa Principal

Console.WriteLine("Fiesta Sin Aplicar El Principio DIP");
new OrganizadorFiesta().IniciarFiesta();

Console.WriteLine("Fiesta Aplicando DIP");
new OrganizadorFiestaD(new Fantasma()).IniciarFIesta();
new OrganizadorFiestaD(new VampiroD()).IniciarFIesta();

class Vampiro
{
    public void Asustar() => Console.WriteLine("Soy un vampiro, voy a beber tu gasolina");
    
}

class OrganizadorFiesta
{
    private Vampiro vampiro = new Vampiro();    // Dependencia Directa

    public void IniciarFiesta()
    {
        Console.WriteLine("Inicia la fiesta!");
        vampiro.Asustar();  // Dependencia Directa
    }
}

// Clases aplicando DIP
interface IAsustador 
{ 
    void Asustar();
}

class Fantasma : IAsustador
{
    public void Asustar() => Console.WriteLine("Fantasma Asusta: Bouu te asusto te asusto");
}

class VampiroD : IAsustador
{
    public void Asustar() => Console.WriteLine("Vampiro Asusta... Brillanding");
}

class OrganizadorFiestaD
{
    IAsustador asustador;
    public OrganizadorFiestaD(IAsustador asustador)
    {
        this.asustador = asustador;
    }

    public void IniciarFIesta()
    {
        Console.WriteLine("Inicianding Fiesta!");
        asustador.Asustar();
    }
}



















