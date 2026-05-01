

using SistemGesionGimansio.MODELOS;

namespace SistemGesionGimansio.SERVICIOS
{
    public class AsignadorRutinas
    {
        public void AsignarRutinaAUsuario(Usuario usuario, Rutina rutina)
        {
            usuario.AsignarRutina(rutina);
        }

        public void AsignarUsuarioAEntrenador(Usuario usuario, Entrenador entrenador)
        {
            entrenador.AgregarUsuario(usuario);
        }
    }
}
