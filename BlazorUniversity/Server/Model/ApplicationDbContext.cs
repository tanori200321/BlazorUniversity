using BlazorUniversity.Server.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorUniversity.Server.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Maestro> Maestros { get; set; }

        public DbSet<Materia> Materias { get; set; }
    }
}