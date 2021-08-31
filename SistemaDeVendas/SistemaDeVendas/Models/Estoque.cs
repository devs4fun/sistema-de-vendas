using System.Collections.Generic;

namespace SistemaDeVendas.Models
{
    public class Estoque
    {
        public Estoque(List<int> quantidadeDeProdutos, List<Produto> produtos)
        {
            QuantidadeDeProdutos = quantidadeDeProdutos;
            Produtos = produtos;
        }

        public List<int> QuantidadeDeProdutos { get; private set; }
        public List<Produto> Produtos { get; private set; }

    }
}
