using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class VendasRequestUpdate
    {
        [Required]
        public decimal Valor { get; set; }
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
    }
}
