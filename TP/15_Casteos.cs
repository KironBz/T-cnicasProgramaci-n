// Casteos


// Conversion implicita, mas pequeño a grande

int numeroEntero = 42;
double numDouble = numeroEntero;
Console.WriteLine(numDouble); //no cambia nada, conversion implicita

// Conversion Explicita, mas grande a pequeño pero recorta 

double numDouble2 = 42.75;
// int numEntero2 = int.Parse(numDouble2); // Parse es una converison implicita, de pequeño a grande

int numEntero2 = (int)numDouble2;  // lo fuerza con el parentesis de mas grande a mas chico
Console.WriteLine(numEntero2);

// Conversion Con Metodos, convert es mas tardado
string texto = "123"; // cadena 1 , 2, 3
// int numerot = texto; // texto no se convierte a entero, implicito
// int numerot = (int)texto; // tampoco forzando, explicito
int numerot = Convert.ToInt32(texto);
Console.WriteLine(numerot); // muestra 123

string texto2 = "3.14";
double doublet = Convert.ToDouble(texto2);
Console.WriteLine(doublet);

// Con parse
texto2 = "3.1416";
doublet = double.Parse(texto2);
Console.WriteLine(doublet);

string texto3 = "31.4";
// int entero4 = int.Parse(texto3); // no se puede por el  .

// Con TryParse
bool exito = int.TryParse(texto3, out int resultado);
Console.WriteLine(exito);
Console.WriteLine(resultado);

texto3 = "314";
 exito = int.TryParse(texto3, out resultado);
Console.WriteLine(exito);
Console.WriteLine(resultado);


// Casteos entre objetos y clases

// Upper casting hijo - padre
Animal miAnimal = new Perro();

// Down Casting padre - hijp
/*Animal animal = new Animal();
Perro perro = (Perro)new Animal();
perro.Ladrar();
*/

//object obj = "Hola mundo";
object obj = miAnimal; // imprimira la clase del objeto
Console.WriteLine(obj);