// Sistema De Analisis De Tormentas electircas

// RECORD - Tupla inmutable (tupla constante), palabras que no cambiaran

// T PTM P D
record Descarga ( double Latitud, double Longitud, double Kilovoltios ) // seran constantes, NO PROPIEDADES
{
    public double DistanciaA(Descarga otra)
    {
        return Math.Sqrt( Math.Pow( Latitud-otra.Latitud, 2 ) + Math.Pow( Longitud - otra.Longitud, 2) );
    }

    public override string ToString()
    {
        return $"({Latitud:F2}, {Longitud:F2}) - {Kilovoltios:F1} KV";
    }
}

// Arbol, Clase para los nodos
public class NodoRayo
{
    // Atributos y propiedes
    public Descarga Descarga { get; set; }
    public int Nivel { get; }
    public List<NodoRayo> Ramas { get; } = new ();
    // Abreviar de new List<NodoRayo>(); 

    // COnstructor
    public NodoRayo(Descarga descarga, int nivel)
    {
        this.Descarga = descarga ;
        this.Nivel = nivel ;
    }
}

public class ArbolRayo
{
    // Atributos y propiedes
    public NodoRayo Origen { get; }

    // Constructor
    public ArbolRayo(Descarga descargaOrigen)
    => Origen = new NodoRayo(descargaOrigen, 0); // una contraccion de no se que

    public void  Bifurcar(NodoRayo padre, Descarga nueva)
    {
        padre.Ramas.Add(new NodoRayo (nueva, padre.Nivel+1) );
    }

    // DFS suma KV de todos los nodos del arbol (primera parte de una busqueda profunda)
    public double IntensidadTotal()
    {
        return SumarKV(Origen);
    }

    private double SumarKV(NodoRayo nodo)
    {
        double total = nodo.Descarga.Kilovoltios;
        foreach (var rama in nodo.Ramas)
        {
            total += SumarKV(rama);
        }
        return total;
    }

    // DFS produndida maxima del arbol
    public int ProfundidadMaxima()
    {
        return Profundidad(Origen);
    }

    private int Profundidad(NodoRayo nodo)
    {
        if (nodo.Ramas.Count == 0)
        {
            return nodo.Nivel;
        }
        return nodo.Ramas.Max( r => Profundidad(r) ) ;
    }

    // Imprimir el arbol con sangria por cada nivel
    public void Imprimir()
    {
        ImprimirNodo(Origen);
    }

    private void ImprimirNodo(NodoRayo nodo)
    {
        string sangria = new string(' ', nodo.Nivel * 3);
        string prefijo = nodo.Nivel == 0 ? "[ORIGEN]" : "└─";
        Console.WriteLine($"{sangria}{prefijo} {nodo.Descarga}");

        foreach(var rama in nodo.Ramas)
        {
            ImprimirNodo(rama);
        }
    }
}

// Clases para sensores
public class SensorNoEncontradoException : Exception
{
    public SensorNoEncontradoException(string id) : base($"Sensor: {id} no registrado en la red")
    {    }
}

public abstract class SensorMeteorologico
{
    public string Id { get; }
    public double Latitud { get; }
    public double Longitud { get; }
    public bool Activo { get; set; } = true;

    // Consturctor
    public SensorMeteorologico(string id, double latitud, double longitud)
    {
        Id = id;
        Latitud = latitud;
        Longitud = longitud;
    }

    // Metodos
    public abstract string Medir();

    public double DistanciaA(Descarga d)
    {
        return Math.Sqrt( Math.Pow(Latitud - d.Latitud) + Math.Pow(Longitud-d.Longitud) );
    }
}

public class SensorDeCampoElectrico : SensorMeteorologico
{
    public SensorDeCampoElectrico(string id, double latitud, double longitud) : base(id, latitud, longitud)
        {   }

    public override string Medir()
    {
        return $"[CE-{Id}] Campo: {new Random().Next(10,200)} V/m";
    }
}

public class SensorAcustico: SensorMeteorologico
{
    public SensorAcustico(string id, double latitud, double longitud) : base(id, latitud, longitud)
    { }

    public override string Medir()
    {
        return $"[AC-{Id}] Nivel Sonoro: {new Random().Next(80, 130)} dB";
    }
}

// Clase para red de sensores
public class RedSensores
{
    // Atibutos y Propiedades
    private Dictionary<string, SensorMeteorologico> sensores = new();
    // Se salta el consturctor

    // Metodos
    public void Registrar(SensorMeteorologico s)
    {
        sensores[s.Id] = s;
    }

    public SensorMeteorologico ObtenerPorID(string id)
    {
        if ( !sensores.TryGetValue(id, out var sensor) )
        {
           throw new SensorNoEncontradoException(id);
        }
        return sensor;
    }

    public Dictionary<string, SensorMeteorologico> SensoresActivos()
    {
        return sensores.Where(par => par.Value.Activo).ToDictionary(par => par.Key, par => par.Value); 
    }
}

// interdaces
public interface IAnalizador
{
    SensorMeteorologico DetectarMasCercano(Descarga descrag); // descarga
    double IntensidadTotal();
    void GnerarReporte();
}

public class AnalizadorTormenta: IAnalizador
{
    public RedSensores Red { get; } = new();
    public ArbolRayo Propagacion { get; }

    public AnalizadorTormenta( Descarga origen)
    => Propagacion = new ArbolRayo(origen);

    // Buscar en el dicionaro el sensor mas cercano
    public SensorMeteorologico DetectarMasCercano(Descarga descarga) // SOlo funciona on snsores activos
    {
        var activos = Red.SensoresActivos();
        if( !activos.Any() )
        {
            throw new InvalidOperationException("Sin sensores activos");
        }

        return activos.Values.MinBy( s => s.DistanciaA(descarga) );
    }

    public double IntensidadTotal()
    {
        return Propagacion.IntensidadTotal();
    }

    public void GenerarReporte()
    {
        Console.WriteLine($"Reporte de tormenta electrica");
        Console.WriteLine($"[Arbol de propagacion del rayo]");
        Propagacion.Imprimir(); 
        Console.WriteLine($"[Intenisdad acumulada] {IntensidadTotal()}");
        Console.WriteLine($"[Profundidad Maxima] {Propagacion.ProfundidadMaxima()}");
        Console.WriteLine($"[Sensores en red] {Red.ToString()}");
        Console.WriteLine($"[Mediciones activas]");
        foreach( var par in Red.SensoresActivos() )
        {
            Console.WriteLine($"[{par.Key}] {par.Value.Medir()}");
        }
    }
}

