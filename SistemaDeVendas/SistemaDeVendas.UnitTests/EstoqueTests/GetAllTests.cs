using Moq;
using SistemaDeVendas.Controllers;
using SistemaDeVendas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SistemaDeVendas.UnitTests.EstoqueTests
{
    public class GetAllTests
    {
        [Fact]
        public void NaoExisteParametros_ExecutaGetAll_VerificaSeListarTodosOsProdutosFoiChamadoUmaVez()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            controller.GetAll();

            // Assert
            estoqueRepositoryMock.Verify(x => x.ListarTodosOsProdutos(), Times.Once);
        }
    }
}
