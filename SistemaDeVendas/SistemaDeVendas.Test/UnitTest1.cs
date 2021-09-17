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
        public void TestandoUmaVendaComClienteNulo()
        {
            //Arrange
            Mock<IVendasRepository> vendasRepositoryMock = new Mock<IVendasRepository>();
            VendasController vendasController = new VendasController(vendasRepositoryMock.Object);
            Venda vendaRequest = new Venda();
            vendaRequest.Cliente = null;

            //Act
            var resultado = vendasController.Post(vendaRequest) as StatusCodeResult;

            ////Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void TestandoUma_VendaCom_ProdutoNulo()
        {
            //Arrange
            Mock<IVendasRepository> vendasRepositoryMock = new Mock<IVendasRepository>();
            VendasController vendasController = new VendasController(vendasRepositoryMock.Object);
            Venda vendaRequest = new Venda();
            vendaRequest.Produto = null;

            //Act
            var resultado = vendasController.Post(vendaRequest) as StatusCodeResult;

            ////Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void Testando_UmaVenda_BemSucedida()
        {
            //Arrange
            Mock<VendasRepository> vendasRepositoryMock = new Mock<VendasRepository>();
            VendasController vendasController = new VendasController(vendasRepositoryMock.Object);

            Cliente clienteTeste = new Cliente()
            {
                Id = 4,
                Nome = "Raphael",
                Telefone = "982112530",
                Endereço = "Rua Sargento Davi nº3",
                Email = "raphaeltest@yahoo.com.br"
            };
            
            Produto produtoTeste = new Produto()
            {
                Id = 1,
                Nome = "Natura Homem",
                Tipo = "Perfume",
                Marca = "Natura",
                Quantidade = 100,
                ValorDeCompra = 30,
                ValorSugeridoDeVenda = 58,
                DataDeValidade = new DateTime(21, 09, 11)
            };
            Venda vendaRequest = new Venda()
            {
                Id = 1,
                Quantidade = 2,
                Cliente = clienteTeste,
                Produto = produtoTeste,
                FormaDePagamento = Pagamento.Pix,
                Status = true
            };

            //Act
            var result = vendasController.Post(vendaRequest) as CreatedResult;

            ////Assert
            //vendasRepositoryMock.Verify(X => X.Criar(vendaRequest), Times.Once);
            Assert.True(result.StatusCode == 201);
        }
    }
}