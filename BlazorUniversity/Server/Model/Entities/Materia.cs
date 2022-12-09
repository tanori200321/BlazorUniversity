using System.ComponentModel.DataAnnotations;

namespace BlazorUniversity.Server.Model.Entities
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int Horario { get; set; }
        public int MatriculaMaestro { get; set; }
        public int MatriculaAlumno { get; set; }

        public List<Alumno> Alumnos { get; set; }
        public List<Maestro> Maestros { get; set; }
    }
}
