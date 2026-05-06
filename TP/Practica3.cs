// Practica 3. Estructura de datos compuestas

// Contexto: Inventario de una tienda de electronicos

// Actividad 1
public class Producto
{
    // Atributos y Propiedades
    public int Id { get; set; }
    public string CodigoBarras { get; set; } // Campo Unico
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public string Stock { get; set; }

    // Metodos
    public override string ToString()
    {
        return $"{Id} | {CodigoBarras} - {Nombre} | {Precio:C} | Stock: {Stock}";
    }
}

public class GestorProductos
{
    // Lista - Para mantener el orden de insercion y permitir ordenamientos
    private List<Producto> listaProductos = new List <Producto> ();

    // Diccionario - Para busquedas rapidas por codigo de barras
    private Dictionary<string, Producto> dicccionarioPorCodigo = new Dictionary<string, Producto> ();

    // Metodos
    // Operaciones con lista
    public void AgragarProductos(Producto p)
    {
        // *Debes asegurarte de que en el diccionario exista el producto
        // Validar Codigo de barras unico (Es el campo unico)
        if ( dicccionarioPorCodigo.ContainsKey(p.CodigoBarras) )
        {
            throw new Exception("El codigo de barras ya existe"); // ya existe, porlo tanto debes de añador en stock
        }
        listaProductos.Add (p);
        dicccionarioPorCodigo[p.CodigoBarras] = p;
    }

    public List<Producto> ObtenerListaProductos()
    {
        return new List<Producto> (listaProductos);
    }

    public bool EliminarProducto(string codigoBarras)
    {
        // Validar Codigo de barras unico (Es el campo unico)
        if (dicccionarioPorCodigo.TryGetValue (codigoBarras, out var producto) )
        {
            listaProductos.Remove(producto);
            dicccionarioPorCodigo.Remove (codigoBarras);
            return true;
        }
        return false;
    }

    public void MostrarInventario()
    {
        Console.WriteLine("Inventario Completo -> Orden De Ingreso");
        foreach( Producto p in listaProductos)
        {
            Console.WriteLine (p.ToString());
        }
    }

    // Operaciones con diccionario (Para Busquedas Especificas)
    public Producto BuscarPorCodigo(string codigoBarras)
    {
        return dicccionarioPorCodigo.TryGetValue(codigoBarras, out var producto) ? producto : null;
    }

    public bool ExisteProducto(string codigoBarras)
    {
        return dicccionarioPorCodigo.ContainsKey (codigoBarras);
    }

    public void MostrarProductosPorCategoria(string categoria)
    {
        foreach(Producto producto in dicccionarioPorCodigo.Values)
        {
            if (producto.Categoria.Equals (categoria, StringComparison.OrdinalIgnoreCase) )
            {
                Console.WriteLine(producto.ToString);
            }
        }
    }
}

// Actividad 2