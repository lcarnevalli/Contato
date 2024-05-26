using System.ComponentModel.DataAnnotations;

namespace Contato.Data.Models
{
    public class Contact
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "DDD deve ser composto por 2 dígitos.")]
        public string DDD { get; set; }

        [Required]
        [RegularExpression(@"^\d{8,9}$", ErrorMessage = "Telefone deve ter entre 8 e 9 dígitos.")]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200, ErrorMessage = "O email deve ter no máximo 200 caracteres.")]
        public string Email { get; set; }

        // Você pode adicionar mais campos conforme necessário aqui

    }
}
