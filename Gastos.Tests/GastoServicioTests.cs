using Gastos.Interfaces;
using Gastos.Modelos;
using Moq;
using Gastos.Negocios;
using NUnit.Framework;

namespace Gastos.Negocios.Tests
{
    public class GastoServicioTests
    {
        [Test]
        public async Task ObtenerTodosLosGastos_DeberiaRetornarListaDeGastos()
        {
            // Arrange
            var mockRepository = new Mock<IGastoRepository>();
            mockRepository.Setup(repo => repo.ObtenerTodosLosGastos())
                          .ReturnsAsync(new List<Gasto> { new Gasto { Id = 1, Descripcion = "Gasto de prueba", Monto = 100 } });

            var servicio = new GastoServicio(mockRepository.Object);

            // Act
            var result = await servicio.ObtenerTodosLosGastos();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1)); // Asegura que se devuelva exactamente un gasto
            Assert.That(result.First().Descripcion, Is.EqualTo("Gasto de prueba")); // Asegura que la descripción sea correcta
        }

        [Test]
        public async Task AgregarGasto_DeberiaAgregarCorrectamente()
        {
            // Arrange
            var mockRepository = new Mock<IGastoRepository>();
            var servicio = new GastoServicio(mockRepository.Object);
            var gastoNuevo = new Gasto { Descripcion = "Nuevo Gasto", Monto = 50 };

            // Act
            await servicio.AgregarGasto(gastoNuevo);

            // Assert
            mockRepository.Verify(repo => repo.AgregarGasto(gastoNuevo), Times.Once); // Verifica que el método se haya llamado una vez
        }

        [Test]
        public async Task ActualizarGasto_DeberiaActualizarCorrectamente()
        {
            // Arrange
            var mockRepository = new Mock<IGastoRepository>();
            var servicio = new GastoServicio(mockRepository.Object);
            var gastoExistente = new Gasto { Id = 1, Descripcion = "Gasto Antiguo", Monto = 100 };

            mockRepository.Setup(repo => repo.ActualizarGasto(gastoExistente)).Returns(Task.CompletedTask);

            // Act
            gastoExistente.Descripcion = "Gasto Actualizado";
            await servicio.ActualizarGasto(gastoExistente);

            // Assert
            mockRepository.Verify(repo => repo.ActualizarGasto(gastoExistente), Times.Once); // Verifica que el método se haya llamado una vez
        }

        [Test]
        public async Task EliminarGasto_DeberiaEliminarCorrectamente()
        {
            // Arrange
            var mockRepository = new Mock<IGastoRepository>();
            var servicio = new GastoServicio(mockRepository.Object);
            var gastoId = 1;

            mockRepository.Setup(repo => repo.EliminarGasto(gastoId))
                          .Returns(Task.CompletedTask);

            // Act
            await servicio.EliminarGasto(gastoId);

            // Assert
            mockRepository.Verify(repo => repo.EliminarGasto(gastoId), Times.Once); // Verifica que el método se haya llamado una vez
        }
    }
}
