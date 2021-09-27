using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaDeVendas.Controllers;
using SistemaDeVendas.Interfaces;
using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SistemaDeVendas.UnitTests.EstoqueTests
{
    public class BuscarTodosTest
    {
        [Fact]
        public void NaoExisteParametros_ExecutaBuscar_VerificaSeListarTodosOsProdutosFoiChamadoUmaVez()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            // Act
            controller.Buscar();

            // Assert
            produtoRepositoryMock.Verify(x => x.ListarTodosOsProdutos(), Times.Once);
        }

        [Fact]
        public void ListaDeProdutosNoBancoENula_ExecutarBuscar_DeveriaRetornarBadRequestResult()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            List<Produto> produtos = null;

            produtoRepositoryMock.Setup(p => p.ListarTodosOsProdutos()).Returns(produtos);

            var resultadoEsperado = 400;

            // Act
            var resultadoRecebido = controller.Buscar() as BadRequestResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }

        [Fact]
        public void NaoExisteParametros_ExecutarBuscar_DeveriaRetornarOkObjectResult()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var produtos = new List<Produto>()
            {
                new Produto(){
                Nome = "Kayak",
                Tipo = "Perfume",
                Marca = "Avon"
                }
            };

            produtoRepositoryMock.Setup(p => p.ListarTodosOsProdutos()).Returns(produtos);

            var resultadoEsperado = 200;

            // Act
            var resultadoRecebido = controller.Buscar() as OkObjectResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }
    }
}
