using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace _2cProg5_2024.Models
{
    public class Cursos
    {
        [Required]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public Cursos(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
