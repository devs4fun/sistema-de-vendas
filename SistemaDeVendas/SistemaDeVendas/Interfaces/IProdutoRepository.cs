using SistemaDeVendas.Models;
using System.Collections.Generic;

namespace SistemaDeVendas.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> ListarTodosOsProdutos();
        Produto PesquisarProdutoPorId(int id);
        void AdicionarProduto(Produto produto);
        void AtualizarProduto(Produto produto);
        void ExcluirProduto(int id);
    }
}
