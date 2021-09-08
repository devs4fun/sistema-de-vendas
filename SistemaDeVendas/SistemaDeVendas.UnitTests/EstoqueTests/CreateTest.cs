using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaDeVendas.Controllers;
using SistemaDeVendas.Interfaces;
using SistemaDeVendas.Models;
using Xunit;

namespace SistemaDeVendas.UnitTests.EstoqueTests
{
    public class CreateTest
    {
        [Fact]
        public void ProdutoEQuantidadeCorretosDeProdutosPassado_ExecutaCreate_VerificaSeAdicionarProdutoFoiChamadoUmaVez() 
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            var produto = new Produto()
            {
                Nome = "Kayak",
                Tipo = "Perfume",
                Marca = "Avon",
                Quantidade = 20
            };

            // Act
            controller.Create(produto, 10);            

            // Assert
            estoqueRepositoryMock.Verify(x => x.AdicionarProduto(produto, 10), Times.Once);
        }

        [Fact]
        public void ProdutoNullEQuantidadeCorretaPassado_ExecutaCreate_DeveriaRetornarUmBadRequestResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            Produto produto = null;

            // Act
            var resultadoEsperado = controller.Create(produto, 10) as BadRequestResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 400);
        }

        [Fact]
        public void ProdutoCorretoEQuantidadeMenorQueUmPassado_ExecutaCreate_DeveriaRetornarUmBadRequestResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            Produto produto = null;

            // Act
            var resultadoEsperado = controller.Create(produto, -1) as BadRequestResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 400);
        }
    }
}
