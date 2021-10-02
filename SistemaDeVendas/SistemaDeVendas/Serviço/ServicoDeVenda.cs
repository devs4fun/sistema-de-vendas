
using SistemaDeVendas.Models;
using SistemaDeVendas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Serviço
{
    public class ServicoDeVenda : IServicoDeVenda
    {
        private readonly IVendasRepository _vendasRepository;
        public ServicoDeVenda(IVendasRepository vendasRepository)
        {
            _vendasRepository = vendasRepository;
        }

        public bool Vender(VendaRequest vendaRequest)
        {
            if (vendaRequest.Produto == null || vendaRequest.Cliente == null)
                return false;

            if (vendaRequest.EhBrinde == true)
            {
                vendaRequest.Produto.ValorSugeridoDeVenda = 0;
            }

             var venda = new Venda(vendaRequest);
             var vendaResponse = _vendasRepository.Criar(venda);

            if (vendaResponse == false)
               return false;

            return true;
        }
    }
}
