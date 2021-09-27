using System;

namespace SistemaDeVendas.Models
{
    public class EstoqueRequest
    {
        public Produto Produto { get; set; }
        public decimal ValorDeCompra { get; set; }
        public DateTime DataDeCompra { get; set; }
        public DateTime DataDeValidade { get; set; }
        public int QuantidadeDeProduto { get; set; }
    }
}