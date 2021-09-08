using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorDeCompra { get; set; }
        public decimal ValorSugeridoDeVenda { get; set; }
        public DateTime DataDeValidade { get; set; }

    }
}
