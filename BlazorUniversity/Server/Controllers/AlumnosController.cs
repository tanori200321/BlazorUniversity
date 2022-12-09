using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorUniversity.Server.Model.Entities;
using BlazorUniversity.Server.Model;
using BlazorUniversity.Shared.DTOs.Alumnos;

namespace BlazorUniversity.Server.Controllers
{
    [ApiController, Route("api/alumnos")]
    public class AlumnosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AlumnosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlumnoDTO>>> GetAlumnos()
        {
            var alumnos = await context.Alumnos.ToListAsync();

            var alumnosDto = new List<AlumnoDTO>();

            foreach (var alumno in alumnos)
            {
                var alumnoDto = new AlumnoDTO();
                alumnoDto.Id = alumno.Id;
                alumnoDto.Nombres = alumno.Nombres;
                alumnoDto.Apellidos = alumno.Apellidos;
                alumnoDto.Correo = alumno.Correo;
                alumnoDto.Edad = alumno.Edad;
                alumnoDto.MatriculaAlumno = alumno.MatriculaAlumno;

                alumnosDto.Add(alumnoDto);
            }
            return alumnosDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlumnoDTO>> GetAlumno(int id)
        {
            var alumno = await context.Alumnos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (alumno == null)
            {
                return NotFound();
            }

            var alumnoDto = new AlumnoDTO();
            alumnoDto.Id = alumno.Id;
            alumnoDto.Nombres = alumno.Nombres;
            alumnoDto.Apellidos = alumno.Apellidos;
            alumnoDto.Correo = alumno.Correo;
            alumnoDto.Edad = alumno.Edad;
            alumnoDto.MatriculaAlumno = alumno.MatriculaAlumno;

            return alumnoDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AlumnoDTO alumnoDto)
        {
            var alumno = new Alumno();
            alumno.Nombres = alumnoDto.Nombres;
            alumno.Apellidos = alumnoDto.Apellidos;
            alumno.Correo = alumnoDto.Correo;
            alumno.Edad = alumnoDto.Edad;
            alumno.MatriculaAlumno = alumnoDto.MatriculaAlumno;

            context.Alumnos.Add(alumno);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] AlumnoDTO alumnoDto)
        {
            var alumnoDb = await context.Alumnos
                .FirstOrDefaultAsync(x => x.Id == alumnoDto.Id);

            if (alumnoDb == null)
            {
                return NotFound();
            }

            alumnoDb.Nombres = alumnoDto.Nombres;
            alumnoDb.Apellidos = alumnoDto.Apellidos;
            alumnoDb.Correo = alumnoDto.Correo;
            alumnoDb.Edad = alumnoDto.Edad;
            alumnoDb.MatriculaAlumno = alumnoDto.MatriculaAlumno;

            context.Alumnos.Update(alumnoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alumnoDb = await context.Alumnos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (alumnoDb == null)
            {
                return NotFound();
            }

            context.Alumnos.Remove(alumnoDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}


