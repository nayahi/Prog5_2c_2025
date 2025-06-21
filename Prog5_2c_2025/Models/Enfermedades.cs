using System.ComponentModel.DataAnnotations;

namespace Prog5_2c_2025.Models
{
    public class Enfermedades
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Enfermedad { get; set; }
    }
}
