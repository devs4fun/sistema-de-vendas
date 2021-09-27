using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class Produto
    {
        public Produto(string nome, string tipo, string marca)
        {
            Nome = nome;
            Tipo = tipo;
            Marca = marca;
        }

        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Tipo { get; private set; }
        public string Marca { get; private set; }
        public decimal MargemDeCompraAtual { get; private set; }
        public List<Estoque> Estoques { get; set; }

        public void CriarEstoque(EstoqueRequest estoqueRequest)
        {
            if (Estoques == null) Estoques = new List<Estoque>();

            Estoques.Add(new Estoque(estoqueRequest));
        }

        public void InformarMargemDeCompra(decimal margemDeCompra)
        {
            MargemDeCompraAtual = margemDeCompra;
        }
    }
}
