namespace SistemGesionGimansio.MODELOS;
public class Usuario
{
    public string Nombre {  get; set; }
    public int Edad {  get; set; }
    public string Objetivo { get; set; }

     public Rutina RutinaAsignada  { get; set; }

    public Usuario(string nombre, int edad, string objetivo)
    {
        Nombre = nombre;
        Edad = edad;
        Objetivo = objetivo;
    }

    public void AsignarRutina(Rutina rutina)
    {
        RutinaAsignada = rutina;
    }
}