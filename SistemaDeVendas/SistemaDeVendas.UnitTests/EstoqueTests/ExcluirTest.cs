using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaDeVendas.Controllers;
using SistemaDeVendas.Interfaces;
using Xunit;

namespace SistemaDeVendas.UnitTests.EstoqueTests
{
    public class ExcluirTest
    {
        [Fact]
        public void InteiroPassadoComoId_ExecutaExcluir_VerificaSeExcluirProdutosFoiChamadoUmaVez()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            controller.Excluir(1);

            // Assert
            estoqueRepositoryMock.Verify(x => x.ExcluirProduto(1), Times.Once);
        }

        [Fact]
        public void InteiroPassadoComoIdEZero_ExecutaExcluir_DeveriaRetornarBadRequestResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            var resultadoEsperado = controller.Excluir(0) as BadRequestResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 400);
        }
    }
}
