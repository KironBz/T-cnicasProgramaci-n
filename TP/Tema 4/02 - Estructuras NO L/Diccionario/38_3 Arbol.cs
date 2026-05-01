// ARBOL
// N numero de nodos (bols agrupables)
// N-1 Aristas  
// Longitud - Ruta de la cantidad de aristas que contiene 

// ARbol binario - 2 Nodos máximo de hijos

// -Datos Nombres d epersona
// -Hijos izquierdo: primer hijo
// -Hijo derecho: segundo hijo

// Recorrer arbol
// Preorden (Padre -> hijo Izquierdo -> Hijo Derecho)
// Inorden (Hijo Izquierdo -> Padre -> Hijo derecho)
// Postorden (Hijo Izquierdo -> Hijo Derecho -> Padre)


var arbol = new ArbolBinario("Juan");
arbol.Raiz.InsertarHijo("Ana", true);
arbol.Raiz.InsertarHijo("Luis", true);

arbol.Raiz.HijoIzquierdo.InsertarHijo("Sofia", true);
arbol.Raiz.HijoIzquierdo.InsertarHijo("Pedro", false);

arbol.Raiz.HijoDerecho.InsertarHijo("Carlos", true);

// Arbol Construido
Console.WriteLine("Arbol Construido");
arbol.ImprimirArbol(arbol.Raiz);

Console.WriteLine();
Console.WriteLine("Preorden");
arbol.RecorrerPreOrden(arbol.Raiz);

Console.WriteLine("\nInorden");
arbol.RecorrerInOrden(arbol.Raiz);

Console.WriteLine("\nPosorden");
arbol.RecorrerPostOrden(arbol.Raiz);


// Clase para crear nodos en el arbol
public class NodoArbol
{
    // Atributos y propiedades
    public string Nombre { get; set; }
    public NodoArbol HijoIzquierdo { get; set; }
    public NodoArbol HijoDerecho { get; set; }

    // COnstructor
    public NodoArbol(string nombre)
    {
        Nombre = nombre;
    }

    public void InsertarHijo(string nombreHijo, bool esHijoIzquierdo)
    {
        if (esHijoIzquierdo)
        {
            HijoIzquierdo = new NodoArbol(nombreHijo);
        }
        else
        {
            HijoDerecho = new NodoArbol(nombreHijo);
        }
    }
}


// Clase para construir el arbol
public class ArbolBinario
{
    // Atributos y propiedades
    public NodoArbol Raiz {  get; set; }

    // COnstructor
    public ArbolBinario(string nombreRaiz)
    {
        Raiz = new NodoArbol(nombreRaiz); ///////////// WTF
    }

    // Metodos
    public void ImprimirArbol(NodoArbol nodo, string prefijo = "", bool esUltimo = true)
    {
        if (nodo == null) return;
        Console.WriteLine(prefijo);
        Console.WriteLine(esUltimo ? "+-- " : "|-- ");
        Console.WriteLine(nodo.Nombre);

        string nuevoPrefijo = prefijo + (esUltimo ? "    " : "|    ");

        if (nodo.HijoIzquierdo != null || nodo.HijoDerecho != null)
        {
            ImprimirArbol(nodo.HijoIzquierdo, nuevoPrefijo, nodo.HijoDerecho == null);
            ImprimirArbol(nodo.HijoDerecho, nuevoPrefijo, true);
        }
    }

    public void RecorrerPreOrden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;
        if (!esPrimero)
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);
        RecorrerPreOrden(nodo.HijoIzquierdo, false);
        RecorrerPreOrden(nodo.HijoDerecho, false);
    }

    public void RecorrerInOrden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;

        RecorrerInOrden(nodo.HijoIzquierdo, false);

        if (!esPrimero)
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);
        RecorrerPreOrden(nodo.HijoDerecho, false);
    }

    public void RecorrerPostOrden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;

        RecorrerPostOrden(nodo.HijoIzquierdo, false);
        RecorrerPostOrden(nodo.HijoDerecho, false);
        if (!esPrimero)
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);
    }

}










