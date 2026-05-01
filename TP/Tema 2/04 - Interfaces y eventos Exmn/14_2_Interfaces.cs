/*
//Ejemplo de interfaces

// Programa Principal
//IEjemplo algue = IEjemplo(); // No se puede declarar por que no tiene constructor, instancias una clase
IEjemplo algo = new EjemploClase();
algo.HacerAlgo();
algo.HacerAlgoMas(); // puede hacerse una implementacion desde la interfaz, pero no es la idea del uso de la interfaz

// Declaracion
public interface IEjemplo
{
    // Definiion de Metodos
    void HacerAlgo();

    // Metodo con Implementacion predeterminada
    public void HacerAlgoMas()
    {
        Console.WriteLine("Haceindo Algo Más");
    }
}

public class EjemploClase : IEjemplo
{
    public void HacerAlgo()
    {
        Console.WriteLine("Haciendo Algo");
    }
}
*/

/////////////////////////////////////////////////////////////////////////////////////////////////
/*

// Programa principal de herencia con polimorfismo

Perro perro = new Perro();
perro.HacerSonido();
Animal otroPerro = new Perro(); 
otroPerro.HacerSonido();

Gato gato = new Gato();
gato.HacerSonido();
Animal otrogato = new Gato(); //se instancia una variable mas grande pero del tipo perro
otrogato.HacerSonido();

Animal paloma = new Paloma();
paloma.HacerSonido();
// paloma.Volar(); // no aparece el .volar

Animal tucan = new Tucan();
tucan.HacerSonido(); // el tucan hace sonido al ser nieto del animal, que heredo del animal
//tucan.volar(); // tampoco puede volar

Paloma otrapaloma = new Paloma(); // Ahora vuela porque se instancio como paloma, pero en Animal no todos los animales vuelan
otrapaloma.HacerSonido();
otrapaloma.Volar();

Paloma otrotucan = new Tucan();
otrotucan.HacerSonido(); // el tucan hace sonido al ser nieto del animal, que heredo del animal
otrotucan.Volar(); // tampoco puede volar

Tucan otro2tucan = new Tucan();
otro2tucan.HacerSonido(); // el tucan hace sonido al ser nieto del animal, que heredo del animal
otro2tucan.Volar(); // tampoco puede volar
*/


// Herencia Con Polimorfismo
// Clase Padre / Base
public class Animal
{
    // Metodos
    public void Respirar()
    {
        Console.WriteLine("Estoy Respirando");
    }

    // Metodo con polimorfismo con herencia
    public virtual void HacerSonido()
    {
        Console.WriteLine("El Animal Hace Sonido");
    }
}

// Clases Hijas
public class Perro: Animal
{
    public void Ladrar()
    {
        Console.WriteLine("Guau guau");
    }

    public override void HacerSonido()
    {
    //    base.HacerSonido(); // Haras el mismo sonido que el animal base
        Ladrar();
    }
}

public class Gato:Animal
{
    public override void HacerSonido()
    {
        Console.WriteLine("Miau Miau");
    }
}

public class Paloma: Animal
{
    public void  Volar()
    {
        Console.WriteLine("Volando");
    }
    public override void HacerSonido()
    {
        Console.WriteLine("Currucu");
    }
}

public class Tucan : Paloma
{
    // A proposito esta vacio
}


/////////////////////////////////////////////////////////////////////////////////////////////////

/*IVolar Pajaro = new PalomaI();
//IVolar otroPajaro = new PerroI(); //Arroja error porque el perro no tiene implementado el volar 
IAnimal otro3Perro = new PerroI();

/*
Animal dragon = new Dragon();
dragon.HacerSonido();
dragon.Volar(); // si se instancia como animal no vuela
*/

/*
Dragon dragon = new Dragon();
dragon.HacerSonido();
dragon.Volar(); // si se genera como interfaz si puede hacer ambos

*/

// Usando Interfaces

public interface IAnimal // interfaz para todos los animales, todos hacen sonido
{
    void HacerSonido();
}

public interface IVolar // interfaz exclusiva para animales voladores
{
    void Volar();
}

public class PerroI : IAnimal // Tiene contrato con interfaz animal
{
    public void HacerSonido()
    {
        Console.WriteLine("Ladrando");
    }
}

public class PalomaI : IAnimal, IVolar
{
    public void HacerSonido()
    {
        Console.WriteLine("Currucu");
    }

    public void Volar()
    {
        Console.WriteLine("Volanding");
    }

}

public class ColibriI : IAnimal, IVolar
{
    public void HacerSonido()
    {
        Console.WriteLine("Colibriando");
    }

    public void Volar()
    {
        Console.WriteLine("Colibri uso volar");
    }

}
/*
public class Animal
{
    // Metodos
    public void Respirar()
    {
        Console.WriteLine("Estoy Respirando");
    }

    // Metodo con polimorfismo con herencia
    public virtual void HacerSonido()
    {
        Console.WriteLine("El Animal Hace Sonido");
    }
}
*/
public class Dragon : Animal, IVolar
{
    public void Volar()
    {
        Console.WriteLine("Dragon vuela");
    }
}