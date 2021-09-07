using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Repository
{
    interface IVendasRepository
    {
        Venda GetById(int id);
        IList<Produto> GetAll();
        bool Post(int id);
        bool Update(Venda venda, VendasRequestUpdate vendasRequest);



    }
}
