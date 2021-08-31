using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class Produto
    {
        public Produto(string nome, string tipo, string marca, int quantidade, decimal valorDecompra)
        {
            Nome = nome;
            Tipo = tipo;
            Marca = marca;
            Quantidade = quantidade;
            ValorDeCompra = valorDecompra;
        }

        public string Nome { get; private set; }
        public string Tipo { get; private set; }
        public string Marca { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorDeCompra { get; set; }
        public decimal ValorSugeridoDeVenda { get; set; }
        public DateTime DataDeValidade { get; set; }

    }
}
