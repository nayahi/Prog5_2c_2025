using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prog5_2c_2025.Models
{
    public class Estudiante2
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Nombre completo")]
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Estudiante2()
        {
        }

        public Estudiante2(int id, string nombre, int edad)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
        }
    }
}
