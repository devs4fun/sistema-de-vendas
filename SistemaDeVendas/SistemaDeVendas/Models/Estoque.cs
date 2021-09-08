using System.Collections.Generic;

namespace SistemaDeVendas.Models
{
    public class Estoque
    {
        public Estoque(int quantidadeDeProdutos, List<Produto> produtos)
        {
            QuantidadeDeProdutos = quantidadeDeProdutos;
            Produtos = produtos;
        }

        public int QuantidadeDeProdutos { get; private set; }
        public List<Produto> Produtos { get; private set; }
    }
}
