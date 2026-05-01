using Xunit;
using SistemGesionGimansio.MODELOS;

namespace SistemaGestionGimnasio.Test
{
    public class UsuarioTest
    {
        [Fact]
        public void AsignarRutina_DebeAsignarCorrectamente()
        {
            // Arrange ¿Que necesito probar?
            Usuario usuario = new Usuario("Juan", 20, "Musculo");
            Rutina rutina = new Rutina("Brazo", 120);

            // Act Evalua que si se va a utilizar 
            usuario.AsignarRutina(rutina);

            // Assert   Evalua si se logro o no
            Assert.Equal("Brazo", usuario.RutinaAsignada.Nombre);
        }
    }
}