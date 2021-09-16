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
    public class AtualizarTest
    {
        [Fact]
        public void ProdutoNullPassado_ExecutaAtualizar_DeveriaRetornarNotFoundResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            Produto produto = null;

            // Act
            var retornoEsperado = controller.Atualizar(produto) as NotFoundResult;

            // Assert
            Assert.True(retornoEsperado.StatusCode == 404);
        }

        [Fact]
        public void ProdutoPassado_ExecutaAtualizar_VerificaSeAtualizarProdutoFoiChamadoUmaVez()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            var produto = new Produto() { Nome = "Kayak", Tipo = "Perfume", Marca = "Avon", Quantidade = 10 };

            // Act
            controller.Atualizar(produto);

            // Assert
            estoqueRepositoryMock.Verify(x => x.AtualizarProduto(produto), Times.Once);
        }

        [Fact]
        public void ProdutoPassado_ExecutaAtualizar_DeveriaRetornarOkResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            var produto = new Produto() { Nome = "Kayak", Tipo = "Perfume", Marca = "Avon", Quantidade = 10 };

            // Act
            var retornoEsperado = controller.Atualizar(produto) as NoContentResult;

            // Assert
            Assert.True(retornoEsperado.StatusCode == 204);
        }
    }
}
