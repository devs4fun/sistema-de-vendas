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
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            controller.Buscar();

            // Assert
            estoqueRepositoryMock.Verify(x => x.ListarTodosOsProdutos(), Times.Once);
        }

        [Fact]
        public void ListaDeProdutosNoBancoENula_ExecutarBuscar_DeveriaRetornarBadRequestResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            List<Produto> produtos = null;

            estoqueRepositoryMock.Setup(p => p.ListarTodosOsProdutos()).Returns(produtos);

            // Act
            var resultadoEsperado = controller.Buscar() as BadRequestResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 400);
        }

        [Fact]
        public void NaoExisteParametros_ExecutarBuscar_DeveriaRetornarOkObjectResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            var produtos = new List<Produto>()
            {
                new Produto(){
                Nome = "Kayak",
                Tipo = "Perfume",
                Marca = "Avon",
                Quantidade = 20
                }
            };

            estoqueRepositoryMock.Setup(p => p.ListarTodosOsProdutos()).Returns(produtos);

            // Act
            var resultadoEsperado = controller.Buscar() as OkObjectResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 200);
        }
    }
}
