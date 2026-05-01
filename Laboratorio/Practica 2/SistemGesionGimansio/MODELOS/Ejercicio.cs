
namespace SistemGesionGimansio.MODELOS
{
    public class Ejercicio
    {
        public string Nombre { get; set; }
        public int Repeticiones { get; set; }
        public int Series {  get; set; }
        public int Descanso {  get; set; }

    public Ejercicio(string nombre, int repeticiones, int series, int descanso)
        {
            Nombre = nombre;
            Repeticiones = repeticiones;
            Series = series;
            Descanso = descanso;
        }

    }
}
