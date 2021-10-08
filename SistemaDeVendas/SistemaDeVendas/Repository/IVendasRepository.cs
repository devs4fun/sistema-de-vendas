using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Repository
{
    public interface IVendasRepository
    {
       bool Criar(Venda venda);
       
        
        // Venda GetById(int id);
       // IList<Produto> GetAll();
       // bool Update(Venda venda, VendaRequest vendasRequest);
       // bool Delete(Venda venda);

    }
}
