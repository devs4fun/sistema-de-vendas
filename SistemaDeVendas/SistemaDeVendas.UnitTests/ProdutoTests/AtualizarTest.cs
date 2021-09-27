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
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            Produto produto = null;

            var resultadoEsperado = 404;

            // Act
            var resultadoRecebido = controller.Atualizar(produto) as NotFoundResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }

        [Fact]
        public void ProdutoPassado_ExecutaAtualizar_VerificaSeAtualizarProdutoFoiChamadoUmaVez()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var produto = new Produto() { Nome = "Kayak", Tipo = "Perfume", Marca = "Avon" };

            // Act
            controller.Atualizar(produto);

            // Assert
            produtoRepositoryMock.Verify(x => x.AtualizarProduto(produto), Times.Once);
        }

        [Fact]
        public void ProdutoPassado_ExecutaAtualizar_DeveriaRetornarOkResult()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var controller = new ProdutoController(produtoRepositoryMock.Object);

            var produto = new Produto() { Nome = "Kayak", Tipo = "Perfume", Marca = "Avon" };

            var resultadoEsperado = 204;

            // Act
            var resultadoRecebido = controller.Atualizar(produto) as NoContentResult;

            // Assert
            Assert.True(resultadoRecebido.StatusCode == resultadoEsperado);
        }
    }
}
