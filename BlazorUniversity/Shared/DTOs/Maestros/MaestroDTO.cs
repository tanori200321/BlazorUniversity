﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUniversity.Shared.DTOs.Maestros
{
    public class MaestroDTO
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
    }
}
