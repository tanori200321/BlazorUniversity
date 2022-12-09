using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUniversity.Shared.DTOs.Materias
{
    public class MateriaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int Horario { get; set; }
        public int MatriculaMaestro { get; set; }
        public int MatriculaAlumno { get; set; }
    }
}