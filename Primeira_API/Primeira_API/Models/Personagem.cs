using System.ComponentModel.DataAnnotations;

namespace Primeira_API.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatorio")]
        [MaxLength(50,ErrorMessage = "Limite de 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Tipo é um campo obrigatorio")]
        [MaxLength(50,ErrorMessage = "Limite de 50 caracteres")]
        public string Tipo { get; set; }
    }
}
