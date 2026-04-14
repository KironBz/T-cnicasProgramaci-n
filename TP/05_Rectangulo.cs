public class Rectangulo
{
    // Atributos
    public float Base{ get; set; } //Encapsulamiento
    public float Altura{ get; set; }

    // Constructro
    public Rectangulo (float base_, int altura)
    {
        Base = base_;
        Altura = altura;
    }

    // Metodos
    public void Perimetro()
    {
        Console.WriteLine($"El perimetro es: {Base* 2f+ Altura * 2f}");
    }
    public void Area()
    {
        float calculoArea;
        calculoArea = Base * Altura;
        Console.WriteLine($"El area es: {calculoArea}");
    }
}
