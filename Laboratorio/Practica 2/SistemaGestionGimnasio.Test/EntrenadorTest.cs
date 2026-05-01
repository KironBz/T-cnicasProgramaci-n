using Xunit;
using SistemGesionGimansio.MODELOS;

namespace SistemaGestionGimnasio.Test
{
    public class EntrenadorTest
    {
        [Fact]

        public void AsignarUsuario_DebeAgregarUsuario()
        {
            // Arrange
            Usuario usuario = new Usuario("Juan", 20, "Musculo");
            Entrenador entrenador = new Entrenador("Pancho", "Musculo");

            // Act
            entrenador.AgregarUsuario(usuario);

            // Assert
            Assert.Contains("Press", entrenador.ObtenerUsuaariosAsignados()[0].Nombre);
            Assert.Contains(usuario, entrenador.ObtenerUsuaariosAsignados());
        }
    }
}
