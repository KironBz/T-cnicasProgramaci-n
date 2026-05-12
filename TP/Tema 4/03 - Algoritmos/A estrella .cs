// Problemas: Robot autonomo que navega en un laberinto
// Mapa matricial:
//
//          C0      C1      C2      C3      C4
//  F0      [s]     [0]     [0]     [1]     [0]         
//  F1      [0]     [1]     [0]     [1]     [0]         
//  F2      [0]     [1]     [0]     [0]     [0]         
//  F3      [0]     [0]     [1]     [1]     [0]         
//  F4      [1]     [0]     [0]     [0]     [G]         


// Nodos de estados // G = 1

public class Nodo
{
    public int X, Y;
    public int G; // Costo desde el inicio
    public int H; // Neurisitca distancia de manhattana la meta
    public int F => G+H; // F(nodo) = gnodo) + h(nodo)

    public Nodo Padre; // Para reconstruir el camino
    public Nodo (int x, int y)
    {
        X = x;
        Y = y;
        G = 0;
        H = 0;
        Padre = null;
    }
}

class AStar
{
    private int[,] grid = { { 0, 0, 0, 1, 0 },
                            { 0, 1, 0, 1, 0 },
                            { 0, 1, 0, 0, 0 },
                            { 0, 0, 1, 1, 0 },
                            { 1, 0, 0, 0, 0 }
                          };
    static int filas = 5;
    static int columnas = 5 ;

    // Heuristica distancia de manhattan
    // h(n) = |x_n - x_meta| + |y_n - y_meta|

    static int Heuristica(Nodo a, Nodo b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    static bool EstaEnQueue(Queue<Nodo> cola, Nodo buscado)
    {
        foreach (Nodo nodo in cola)
        {
            if (nodo.X == buscado.X && nodo.Y == buscado.Y)
            {
                return true;
            }
        }
        return false;
    }

}