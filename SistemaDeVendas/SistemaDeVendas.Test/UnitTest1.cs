using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaDeVendas.Controllers;
using SistemaDeVendas.Models;
using SistemaDeVendas.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace SistemaDeVendas.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestandoUmaVenda()
        {
            //Arrange
            Mock<IVendasRepository> vendasRepositoryMock = new Mock<IVendasRepository>();
            VendasController vendasController = new VendasController(vendasRepositoryMock.Object);
            var venda = new Venda(){
                Id = 1,
                Quantidade = 10 
            };
            //Act
            //vendasController.Patch(1);

            ////Assert
            //vendasRepositoryMock.Verify(x => x.Patch(venda.Id), Times.Once);

        }
    }
}

