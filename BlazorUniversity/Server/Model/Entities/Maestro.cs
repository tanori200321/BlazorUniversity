using System.ComponentModel.DataAnnotations;

namespace BlazorUniversity.Server.Model.Entities
{
    public class Maestro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }

        public int Edad { get; set; }

        [Required]
        public int MatriculaMaestro { get; set; }

        public int MateriaId { get; set; }
        public Materia Materias { get; set; }

    }
}
