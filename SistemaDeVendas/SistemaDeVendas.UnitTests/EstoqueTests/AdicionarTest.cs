using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaDeVendas.Controllers;
using SistemaDeVendas.Interfaces;
using SistemaDeVendas.Models;
using Xunit;

namespace SistemaDeVendas.UnitTests.EstoqueTests
{
    public class AdicionarTest
    {
        [Fact]
        public void ProdutoNullPassado_ExecutaAdicionar_DeveriaRetornarUmBadRequestResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            Produto produto = null;

            // Act
            var resultadoEsperado = controller.Adicionar(produto) as BadRequestResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 400);
        }

        [Fact]
        public void ProdutoCorretoPassado_ExecutaAdicionar_VerificaSeAdicionarProdutoFoiChamadoUmaVez() 
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
            controller.Adicionar(produto);            

            // Assert
            estoqueRepositoryMock.Verify(x => x.AdicionarProduto(produto), Times.Once);
        }

        [Fact]
        public void ProdutoCorretoPassado_ExecutaAdicionar_DeveriaRetornarOkResult()
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
            var resultadoEsperado = controller.Adicionar(produto) as OkResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 200);
        }
    }
}
