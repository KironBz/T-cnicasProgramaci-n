using Xunit;
using SistemGesionGimansio.MODELOS;

namespace SistemaGestionGimnasio.Test
{
    public class RutinaTest
    {
        [Fact]

        public void AgregarEjercicio_DebeAgregarALista()
        {
            // Arrange
            Rutina rutina = new Rutina("Brazo", 120);
            Ejercicio ejercicio1 = new Ejercicio("Press", 4, 2, 60);
            Ejercicio ejercicio2 = new Ejercicio("Fondos", 10, 3, 60);
            Ejercicio ejercicio3 = new Ejercicio("Lagartijas", 15, 3, 60);

            // Act

        }
    }
}
