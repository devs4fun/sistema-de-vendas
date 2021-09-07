using System.ComponentModel.DataAnnotations;

namespace SistemaDeVendas.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Telefone { get; set; }
        public int CPF { get; set; }
        [Required]
        public string Endereço { get; set; }
        public string Email { get; set; }

    }
}