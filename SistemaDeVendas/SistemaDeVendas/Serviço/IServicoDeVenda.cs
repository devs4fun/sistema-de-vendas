using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Serviço
{
    public interface IServicoDeVenda
    {
        public bool Vender(VendaRequest vendarequest);

    }
}
