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
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            Produto produto = null;

            var resultadoEsperado = 400;

            // Act
            var resultadoRecebido = controller.Adicionar(produto) as BadRequestResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }

        [Fact]
        public void ProdutoCorretoPassado_ExecutaAdicionar_VerificaSeAdicionarProdutoFoiChamadoUmaVez() 
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var produto = new Produto()
            {
                Nome = "Kayak",
                Tipo = "Perfume",
                Marca = "Avon"
            };

            // Act
            controller.Adicionar(produto);            

            // Assert
            produtoRepositoryMock.Verify(x => x.AdicionarProduto(produto), Times.Once);
        }

        [Fact]
        public void ProdutoCorretoPassado_ExecutaAdicionar_DeveriaRetornarOkResult()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var produto = new Produto()
            {
                Nome = "Kayak",
                Tipo = "Perfume",
                Marca = "Avon"
            };

            var resultadoEsperado = 200;

            // Act
            var resultadoRecebido = controller.Adicionar(produto) as OkResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }
    }
}
