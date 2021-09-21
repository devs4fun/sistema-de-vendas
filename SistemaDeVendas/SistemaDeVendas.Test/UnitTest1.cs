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
            Produto produtoRequest = new Produto()
            {
                Nome = "kaiak",
                Tipo = "perfume",
                Marca = "Natura",
                Quantidade = 10,
                ValorDeCompra = 100,
                ValorSugeridoDeVenda = 150,
                DataDeValidade = new DateTime(21, 10, 02)
            };
            VendaRequest vendaRequest = new VendaRequest();
            vendaRequest.Produto = produtoRequest;

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
            Cliente clienteRequest = new Cliente()
            {
                Nome = "eu",
                CPF = "215.154.653-52",
                Telefone = "22154876",
                Email = "raphael.sants@hotmail.com",
                Endereço = "rua sagent davi n3"
            };
            VendaRequest vendaRequest = new VendaRequest();
            vendaRequest.Cliente = clienteRequest;

            //Act
            var resultado = vendasController.Post(vendaRequest) as StatusCodeResult;

            ////Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void Testando_UmaVenda_BemSucedida()
        {
            //Arrange
            Mock<IVendasRepository> vendasRepositoryMock = new Mock<IVendasRepository>();
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
            VendaRequest vendaRequest = new VendaRequest()
            {
                Quantidade = 2,
                Cliente = clienteTeste,
                Produto = produtoTeste,
                FormaDePagamento = Pagamento.Pix,
                Status = true
            };
            vendasRepositoryMock.Setup(x => x.Criar(It.IsAny<Venda>())).Returns(true);
            

            //Act
            var result = vendasController.Post(vendaRequest) as ObjectResult;

            ////Assert
            
            Assert.True(result.StatusCode == 201);
        }

        public void Testando_QuantidadeDeVenda_BemSucedida()
        {
            //Arrange
            Mock<IVendasRepository> vendasRepositoryMock = new Mock<IVendasRepository>();
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
            VendaRequest vendaRequest = new VendaRequest()
            {
                Quantidade = 2,
                Cliente = clienteTeste,
                Produto = produtoTeste,
                FormaDePagamento = Pagamento.Pix,
                Status = true
            };
            vendasRepositoryMock.Setup(x => x.Criar(It.IsAny<Venda>())).Returns(true);


            //Act
            var result = vendasController.Post(vendaRequest) as ObjectResult;

            ////Assert
            vendasRepositoryMock.Verify(X => X.Criar(It.IsAny<Venda>()), Times.Exactly(1));
           
        }
    }
}