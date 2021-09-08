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
    public class GetTests
    {
        [Fact]
        public void StringDePesquisaPassada_ExecutaGet_VerificaSePesquisarProdutoFoiChamadoUmaVez()
        {
            // Arrange
            var stringPesquisa = "Kayak 1";

            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            controller.Get(stringPesquisa);

            // Assert
            estoqueRepositoryMock.Verify(x => x.PesquisarProduto(stringPesquisa), Times.Once);
        }
    }
}
