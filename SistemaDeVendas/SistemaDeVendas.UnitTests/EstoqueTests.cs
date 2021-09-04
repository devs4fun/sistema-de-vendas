using Moq;
using SistemaDeVendas.Interfaces;
using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SistemaDeVendas.UnitTests
{
    public class EstoqueTests
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public EstoqueTests(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        [Fact]
        public void DadosDeProdutoOK_CadastrarProduto_RetornarProdutoId()
        {
            //Arrange
            var produtoFake = new Produto("Kayak", "Perfume", "Avon", 20);
            var quantidadeDeProdutos = 10;
            var idEsperado = 1;

            //Act
             var id = _estoqueRepository.AdicionarProduto(produtoFake, quantidadeDeProdutos);

            //Assert
            Assert.Equal(id, idEsperado);
            
        }

        [Fact]
        public void TresProdutosExistem_ListarProdutos_RetornarListaDeProdutos()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto("Kayak 1", "Perfume", "Avon", 20),
                new Produto("Kayak 2", "Perfume", "Avon", 25),
                new Produto("Kayak 3", "Perfume", "Avon", 30),
            };

            var estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            estoqueRepositoryMock.Setup(pr => pr.ListarTodosOsProdutos()).Returns(produtos);


            // Act


            // Assert
            estoqueRepositoryMock.Verify(x => x.ListarTodosOsProdutos(), Times.Once);

        }
    }
}
