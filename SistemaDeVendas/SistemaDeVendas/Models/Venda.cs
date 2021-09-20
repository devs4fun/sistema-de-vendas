using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class Venda
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public Produto Produto { get; set; }
        [Required]
        public Pagamento FormaDePagamento { get; set; }
        [Required]
        public bool Status { get; set; }

        public Venda(VendaRequest vendaRequest)
        {
            Quantidade = vendaRequest.Quantidade;
            Cliente = vendaRequest.Cliente;
            Produto = vendaRequest.Produto;
            FormaDePagamento = vendaRequest.FormaDePagamento;
            Status = vendaRequest.Status;
        }

    }
}
