/* 
 * SI una clase B es hija de la clase A, 
 * Entonces B se debe poder usar donde esperamos A
 * Sustitucion de liskov es uno de los mas usados
*/

// Sin usar LSP

// Programa principal usando rectangulo y cuadrado


// Tratar de hacer el uppercasting, convertir un objeto a Cuadrado a un Rectangulo

Rectangulo rectangulo = new Cuadrado();

// Si establecemos solo una de las propiedades se comporta como un cuadrado
rectangulo.Ancho = 4;
Console.WriteLine(rectangulo.CalcularArea()); // Comporta como cuadrado y no cumple
rectangulo.Ancho = 5;
Console.WriteLine(rectangulo.CalcularArea()); // Comporta como cuadrado y no cumple

Console.WriteLine();
Console.WriteLine("Usando LSP");
Console.WriteLine();

// Usando LSP
Forma rectanguloLSP = new RectanguloLSP { Ancho = 5, Alto = 4 };
Forma cuadradoLSP = new CuadradoLSP { Lado = 4 };

ImprimirArea(rectanguloLSP);
ImprimirArea(cuadradoLSP);


static void ImprimirArea(Forma forma)
{
    Console.WriteLine($"El Area Es: {forma.CalcularArea()}");
}




public class Rectangulo
{
    public virtual int Ancho {  get; set; }
    public virtual int Alto { get; set; }

    public int CalcularArea()
    {
        return Ancho * Alto;
    }
}

public class Cuadrado : Rectangulo
{
    public override int Ancho { set { base.Ancho = base.Alto = value; } }  // Pueden ir con el mismo orden o no, no importa
    public virtual int Alto { set { base.Alto = base.Ancho = value; } } // Pueden ir con el mismo orden o no, no importa

}

// Aplicando LSP
public abstract class Forma
{
    public abstract int CalcularArea();

}

public class RectanguloLSP : Forma
{
    public int Ancho { get; set; }
    public int Alto { get; set; }

    public override int CalcularArea()
    {
        return Ancho * Alto;
    }
}

public class CuadradoLSP : Forma
{
    public int Lado { get; set; }

    public override int CalcularArea()
    {
        return Lado * Lado;
    }
}