using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Repository
{
    public class VendasRepository : IVendasRepository
    {
        private static IList<Produto> produtos = new List<Produto>();

        public bool Post(int id)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var response = aplicacaoContext.Produtos.FirstOrDefault(x => x.Id == id);
            aplicacaoContext.Produtos.Remove(response);
            aplicacaoContext.SaveChanges();
            return true;
        }

        public Venda GetById(int id)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var venda = aplicacaoContext.Vendas.FirstOrDefault(x => x.Id == id);
            return venda;
        }

        public IList<Produto> GetAll()
        {
            return produtos;
        }

        public bool Update(Venda venda, VendasRequestUpdate vendarequest)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var vendaToDelete = aplicacaoContext.Vendas.FirstOrDefault(x => x.Id == venda.Id);
            aplicacaoContext.Remove(vendaToDelete);
            aplicacaoContext.Add(vendarequest);

            return true;
        }

        public bool Delete(Venda venda)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var vendaToDelete = aplicacaoContext.Vendas.FirstOrDefault(x => x.Id == venda.Id);
            aplicacaoContext.Vendas.Remove(vendaToDelete);

            return true;
        }
    }
}
