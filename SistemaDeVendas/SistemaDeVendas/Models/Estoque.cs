using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class Estoque
    {
        public Estoque(HistoricoDeCompraRequest request)
        {
            Produto = request.Produto;
            ValorDeCompra = request.ValorDeCompra;
            DataDeCompra = request.DataDeCompra;
            DataDeValidade = request.DataDeValidade;
            QuantidadeDeProduto = request.QuantidadeDeProduto;
        }
        public int Id { get; set; }
        public Produto Produto { get; private set; }
        public decimal ValorDeCompra { get; private set; }
        public decimal ValorSugerido => ValorDeCompra * 1.3M;
        public DateTime DataDeCompra { get; private set; }
        public DateTime DataDeValidade { get; private set; }
        public int QuantidadeDeProduto { get; private set; }

    }
}
