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
    public class GetByIdTests
    {
        [Fact]
        public void InteiroPassadoComoId_ExecutaGetById_VerificaSePesquisarPorIdFoiChamadoUmaVez()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            controller.GetById(1);

            // Assert
            estoqueRepositoryMock.Verify(x => x.PesquisarProdutoPorId(1), Times.Once);
        }

        [Fact]
        public void IdDeProdutoNaoExisteNoBanco_ExecutaGetById_VerificaSeRetornaNotFound()
        {
            // Arrange
            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            var controller = new EstoquesController(estoqueRepositoryMock.Object);

            // Act
            var resultadoEsperado = controller.GetById(1) as NotFoundResult;

            // Assert
            Assert.True(resultadoEsperado.StatusCode == 404);
        }
    }
}
