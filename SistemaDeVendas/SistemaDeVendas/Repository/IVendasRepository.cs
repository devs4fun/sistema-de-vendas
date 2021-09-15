﻿using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Repository
{
    public interface IVendasRepository
    {
        Venda GetById(int id);
        IList<Produto> GetAll();
        bool Criar(Venda venda);
        bool Update(Venda venda, VendasRequestUpdate vendasRequest);
        bool Delete(Venda venda);

    }
}
