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
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            var resultadoEsperado = controller.BuscarPorId(0) as BadRequestResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 400);

        }
        [Fact]
        public void InteiroPassadoComoId_ExecutaBuscarPorId_VerificaSePesquisarPorIdFoiChamadoUmaVez()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            controller.BuscarPorId(1);

            // Assert
            estoqueRepositoryMock.Verify(x => x.PesquisarProdutoPorId(1), Times.Once);
        }

        [Fact]
        public void IdDeProdutoNaoExisteNoBanco_ExecutaBuscarPorId_DeveriaRetornarNotFound()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            var resultadoEsperado = controller.BuscarPorId(1) as NotFoundResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 404);
        }

        [Fact]
        public void InteiroPassadoComoId_ExecutaBuscarPorId_DeveriaRetornarOkObjectResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            var produto = new Produto() { Nome = "Kayak", Tipo = "Perfume", Marca = "Avon", Quantidade = 10 };

            estoqueRepositoryMock.Setup(p => p.PesquisarProdutoPorId(1)).Returns(produto);

            // Act
            var resultadoEsperado = controller.BuscarPorId(1) as OkObjectResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 200);
        }
    }
}
