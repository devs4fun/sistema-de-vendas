using Moq;
using SistemaDeVendas.Controllers;
using SistemaDeVendas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SistemaDeVendas.UnitTests.EstoqueTests
{
    public class DeleteTests
    {
        [Fact]
        public void InteiroPassadoComoId_ExecutaDelete_VerificaSeExcluirProdutosFoiChamadoUmaVez()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            controller.Delete(1);

            // Assert
            estoqueRepositoryMock.Verify(x => x.ExcluirProduto(1), Times.Once);
        }
    }
}
