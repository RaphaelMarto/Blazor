using System.ComponentModel.DataAnnotations;

namespace DemoWASM.Models
{
    public class Gamer
    {
        public int Id { get; set; }

        [Required]
        public string Pseudo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Le mot de passe doit contenir au minimum 8 caractères.")]
        [MaxLength(64, ErrorMessage = "Le mot de passe doit contenir au maximum 64 caractères.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime DateDeNaissance { get; set; }
    }
}
