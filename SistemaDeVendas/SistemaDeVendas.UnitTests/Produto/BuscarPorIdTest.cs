using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaDeVendas.Controllers;
using SistemaDeVendas.Interfaces;
using SistemaDeVendas.Models;
using Xunit;

namespace SistemaDeVendas.UnitTests.EstoqueTests
{
    public class BuscarPorIdTest
    {
        [Fact]
        public void InteiroPassadoComoIdIgualAZero_ExecutaBuscarPorId_DeveriaRetornarBadRequestResult()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var resultadoEsperado = 400;

            // Act
            var resultadoRecebido = controller.BuscarPorId(0) as BadRequestResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);

        }
        [Fact]
        public void InteiroPassadoComoId_ExecutaBuscarPorId_VerificaSePesquisarPorIdFoiChamadoUmaVez()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            // Act
            controller.BuscarPorId(1);

            // Assert
            produtoRepositoryMock.Verify(x => x.PesquisarProdutoPorId(1), Times.Once);
        }

        [Fact]
        public void IdDeProdutoNaoExisteNoBanco_ExecutaBuscarPorId_DeveriaRetornarNotFound()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var resultadoEsperado = 404;

            // Act
            var resultadoRecebido = controller.BuscarPorId(1) as NotFoundResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }

        [Fact]
        public void InteiroPassadoComoId_ExecutaBuscarPorId_DeveriaRetornarOkObjectResult()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var produto = new Produto() { Nome = "Kayak", Tipo = "Perfume", Marca = "Avon" };

            produtoRepositoryMock.Setup(p => p.PesquisarProdutoPorId(1)).Returns(produto);

            var resultadoEsperado = 200;

            // Act
            var resultadoRecebido = controller.BuscarPorId(1) as OkObjectResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }
    }
}
