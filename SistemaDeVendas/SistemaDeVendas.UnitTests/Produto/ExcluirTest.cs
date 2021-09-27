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
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            // Act
            controller.Excluir(1);

            // Assert
            produtoRepositoryMock.Verify(x => x.ExcluirProduto(1), Times.Once);
        }

        [Fact]
        public void InteiroPassadoComoIdEZero_ExecutaExcluir_DeveriaRetornarBadRequestResult()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var resultadoEsperado = 400;

            // Act
            var resultadoRecebido = controller.Excluir(0) as BadRequestResult;
            
            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }
    }
}
