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
    public class UpdateTests
    {
        [Fact]
        public void ProdutoNaoNullPassado_ExecutaUpdate_VerificaSeAtualizarProdutoFoiChamadoUmaVez()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            var produto = new Produto() { Nome = "Kayak", Tipo = "Perfume", Marca = "Avon", Quantidade = 10 };

            // Act
            controller.Update(produto);

            // Assert
            estoqueRepositoryMock.Verify(x => x.AtualizarProduto(produto), Times.Once);
        }

        [Fact]
        public void ProdutoNullPassado_ExecutaUpdate_DeveriaRetornarNotFoundResult()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            Produto produto = null;

            // Act
            var retornoEsperado = controller.Update(produto) as NotFoundResult;

            // Assert
            Assert.True(retornoEsperado.StatusCode == 404);
        }
    }
}
