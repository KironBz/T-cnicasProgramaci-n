// Practica 3. Estructura de datos compuestas
// Contexto: Inventario de una tienda de electronicos

// Crear una instancia del gestor de productos
var gestor = new GestorProductos();

//Actividad 1 Implementar Las Estructuras
Console.WriteLine("Estrucutras de Datos");

// Agrefar productos
gestor.AgregarProductos(
        new Producto
        {
            Id = 3,
            CodigoBarras = "123456",
            Nombre = "Audifonos",
            Categoria = "Audio",
            Precio = 5.99m,
            Stock = 10
        }
    );

gestor.AgregarProductos(
        new Producto
        {
            Id = 1,
            CodigoBarras = "789456",
            Nombre = "XBox",
            Categoria = "Entretenimiento",
            Precio = 1000m,
            Stock = 10
        }
    );

gestor.AgregarProductos(
        new Producto
        {
            Id = 4,
            CodigoBarras = "456123",
            Nombre = "Mouse",
            Categoria = "Accesorios",
            Precio = 60m,
            Stock = 15
        }
    );

gestor.AgregarProductos(
        new Producto
        {
            Id = 2,
            CodigoBarras = "741258",
            Nombre = "PlayStation",
            Categoria = "Entretenimiento",
            Precio = 1500m,
            Stock = 15
        }
    );

// Mostrar Inventario
gestor.MostrarInventario();

// mostrar por Categoria
gestor.MostrarProductosPorCategoria("Entretenimiento");

// BUscar por codigo de barras
Console.WriteLine("Buscando producto con codigo 123456");
var productoEncontrado = gestor.BuscarPorCodigo("123456");
Console.WriteLine(productoEncontrado != null ? productoEncontrado.ToString() : "No Encontrado");

// Actividad 2
Console.WriteLine("Algoritmos de Ordenacoin");

// Creando una copia de la lista a ordenar
var productosParaOrdenarPrecio = new List<Producto>(gestor.ObtenerListaProductos());
Console.WriteLine("Orden por precio");
Ordenador.QuickSortPorPrecio(productosParaOrdenarPrecio);
MostrarListaProductos(productosParaOrdenarPrecio);

// Ordenar por nombre
var productosParaOrdenarNombre = new List<Producto>(gestor.ObtenerListaProductos());
Console.WriteLine("Orden por Nombre");
var productosOrdenadosMerge = Ordenador.MergeSortPorNombre(productosParaOrdenarNombre);
MostrarListaProductos(productosParaOrdenarNombre);

// Actividad 3 Algoritmos de Busqueda


// Ordenar por ID
var productosORdenadosId = new List<Producto>(gestor.ObtenerListaProductos());
Ordenador.QuickSortPorId(productosORdenadosId);
Console.WriteLine("Busqueda Binaria Por Id");
var (productoBin, iterBin) = Buscador.BusquedaBinaria(productosORdenadosId, 3);
Console.WriteLine( $"Resultado: {productoBin ?.ToString() ?? "No Encontrado"} | Iteracopmes {iterBin}" );

// Ordenar por Nombre
var productosORdenadosNombre = new List<Producto>(gestor.ObtenerListaProductos());
Ordenador.MergeSortPorNombre(productosORdenadosNombre);
Console.WriteLine("Busqueda Secuencial Por Nombre: Audifonos");
var (productoNom, iterNom) = Buscador.BusquedaSecuencial(productosORdenadosNombre, "Audifonos");
Console.WriteLine($"Resultado: {productoBin?.ToString() ?? "No Encontrado"} | Iteracopmes {iterNom}");

// Funcion Auxiliar para mostrar elementos en listas
static void MostrarListaProductos(List<Producto> productos) // Quitar el static?
{
    foreach (Producto producto in productos)
    {
        Console.WriteLine(producto.ToString());
    }    
}


///////////////////////////////////////////////////////////////////////


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
    public void AgregarProductos(Producto p)
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

// Actividad 2 primer algoritmo quick sort, pivote de izquierda a derecha
public class Ordenador
{
    // QuickSort
    public static void QuickSortPorId(List<Producto> productos) 
    {
        // Caso en el que termina la recursividad
        if(productos.Count <= 0)
        {
            return;
        }

        // 1.- Seleccionar el pivote
        Producto pivote = productos[productos.Count-1];
        var menores = new List<Producto>();
        var mayores = new List<Producto>();

        // 2.- Reorganizar la lista para determinar < al pivote o > al pivote
        for (int i = 0; i < productos.Count-1; i++)
        {
            if (productos[i].Id < pivote.Id)
            {
                menores.Add(productos[i]);
            }
            else 
            {
                mayores.Add(productos[i]);
            }
        }

        // 3.- Recursivamente aplicar el algoritmo
        QuickSortPorId(menores);
        QuickSortPorId (mayores);
        
        // 4.- Reconstruir lista con elementos ordenados
        productos.Clear();
        productos.AddRange(menores);
        productos.Add(pivote);
        productos.AddRange (mayores);
    }

    public static void QuickSortPorPrecio(List<Producto> productos)
    {
        // Caso en el que termina la recursividad
        if (productos.Count <= 1)
        {
            return;
        }

        // 1.- Seleccionar el pivote
        Producto pivote = productos[productos.Count - 1];
        var menores = new List<Producto>();
        var mayores = new List<Producto>();

        // 2.- Reorganizar la lista para determinar < al pivote o > al pivote
        for (int i = 0; i < productos.Count - 1; i++)
        {
            if (productos[i].Precio < pivote.Precio)
            {
                menores.Add(productos[i]);
            }
            else
            {
                mayores.Add(productos[i]);
            }
        }

        // 3.- Recursivamente aplicar el algoritmo
        QuickSortPorPrecio(menores);
        QuickSortPorPrecio(mayores);

        // 4.- Reconstruir lista con elementos ordenados
        productos.Clear();
        productos.AddRange(menores);
        productos.Add(pivote);
        productos.AddRange(mayores);
    }

    // MergeSort
    public static List<Producto> MergeSortPorNombre(List<Producto> productos)
    {
        // Caso que detiene la recursividad
        if(productos.Count<=1)
        {
            return productos;
        }

        // 1.- Dividir la lista en dos partes
        int mitad = productos.Count / 2;
        var izquierda = productos.GetRange(0, mitad);
        var derecha = productos.GetRange(mitad, productos.Count-mitad);

        // 2.- Ordenar recurisvamente cada mitad
        izquierda = MergeSortPorNombre(izquierda);
        derecha = MergeSortPorNombre(derecha);

        // 3.- Mezclasr las dos mitades
        return Mezclar(izquierda, derecha);
    }

    private static List<Producto> Mezclar(List<Producto> izquierda, List<Producto> derecha)
    {
        var resultado = new List<Producto>();
        int i = 0; int j = 0;

        // 4.- Comparar y agregar en orden
        while (i < izquierda.Count && j < derecha.Count)
        {
            if (string.Compare(izquierda[i].Nombre, derecha[j].Nombre) <0 )
            {
                resultado.Add(izquierda[i++]);
            }
            else
            {
                resultado.Add(derecha[i++]);
            }
        }
        
        // 5.- Agregar los elementos restantes
        while (i< izquierda.Count)
        {
            resultado.Add(izquierda[i++]);
        }
        while (j < derecha.Count)
        {
            resultado.Add(derecha[j++]);
        }
        return resultado;
    }


    //////////////////////////////////////////////////////////////////////////////
    public static List<Producto> MergeSortPorPrecio(List<Producto> productos)
    {
        // Caso que detiene la recursividad
        if (productos.Count <= 1)
        {
            return productos;
        }

        // 1.- Dividir la lista en dos partes
        int mitad = productos.Count / 2;
        var izquierda = productos.GetRange(0, mitad);
        var derecha = productos.GetRange(mitad, productos.Count - mitad);

        // 2.- Ordenar recurisvamente cada mitad
        izquierda = MergeSortPorPrecio(izquierda);
        derecha = MergeSortPorPrecio(derecha);

        // 3.- Mezclasr las dos mitades
        return MezclarPrecio(izquierda, derecha);
    }

    private static List<Producto> MezclarPrecio(List<Producto> izquierda, List<Producto> derecha)
    {
        var resultado = new List<Producto>();
        int i = 0; int j = 0;

        // 4.- Comparar y agregar en orden
        while (i < izquierda.Count && j < derecha.Count)
        {
            if (izquierda[i].Precio < derecha[j].Precio)
            {
                resultado.Add(izquierda[i++]);
            }
            else
            {
                resultado.Add(derecha[i++]);
            }
        }

        // 5.- Agregar los elementos restantes
        while (i < izquierda.Count)
        {
            resultado.Add(izquierda[i++]);
        }
        while (j < derecha.Count)
        {
            resultado.Add(derecha[j++]);
        }
        return resultado;
    }
}

// Actividad 3 Algoritmo de Busqueda
public class Buscador
{
    // Busqueda Binaria (Lista ordenada por ID)
    public static (Producto, int) BusquedaBinaria(List<Producto> productos, int idBuscado)
    {
        int inicio = 0;
        int fin = productos.Count - 1;
        int iteraciones = 0;

        while (inicio <= fin)
        {
            iteraciones++;

            // 1.- Calcular el punto medio
            int medio = (inicio + fin) / 2;

            // 2.- Comprobar si encontramos el ID
            if (productos[medio].Id == idBuscado)
            {
                return (productos[medio], iteraciones);
            }

            // 3.- Ajustar limites de busqueda
            if (productos[medio].Id < idBuscado)
            {
                inicio = medio + 1; // Buscar en la mitad derecha 
            }
            else
            {
                fin = medio - 1; // Buscar en la mitad izquierda
            }
        }
        return (null, iteraciones); // No encontrado
    }

    public static (Producto, int) BusquedaSecuencial(List<Producto> productos, string nombreBuscado)
    {
        int iteraciones = 0;

        // 1.- Recorrer la lista elemento a elemento
        foreach (Producto producto in productos)
        {
            iteraciones++;

            // 2.- Comparar el nombre con el buscado
            if(producto.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase) )
            {
                return (producto, iteraciones);
            }
        }
        return (null, iteraciones); //
    }
}


