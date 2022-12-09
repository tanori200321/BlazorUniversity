using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorUniversity.Server.Model.Entities;
using BlazorUniversity.Server.Model;
using BlazorUniversity.Shared.DTOs.Maestros;

namespace BlazorUniversity.Server.Controllers
{
    [ApiController, Route("api/maestros")]
    public class MaestrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MaestrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MaestroDTO>>> GetMaestros()
        {
            var maestros = await context.Maestros.ToListAsync();

            var maestrosDto = new List<MaestroDTO>();

            foreach (var maestro in maestros)
            {
                var maestroDto = new MaestroDTO();
                maestroDto.Id = maestro.Id;
                maestroDto.Nombres = maestro.Nombres;
                maestroDto.Apellidos = maestro.Apellidos;
                maestroDto.Correo = maestro.Correo;
                maestroDto.Edad = maestro.Edad;
                maestroDto.MatriculaMaestro = maestro.MatriculaMaestro;

                maestrosDto.Add(maestroDto);
            }
            return maestrosDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MaestroDTO>> GetMaestro(int id)
        {
            var maestro = await context.Maestros
                .FirstOrDefaultAsync(x => x.Id == id);

            if (maestro == null)
            {
                return NotFound();
            }

            var maestroDto = new MaestroDTO();
            maestroDto.Id = maestro.Id;
            maestroDto.Nombres = maestro.Nombres;
            maestroDto.Apellidos = maestro.Apellidos;
            maestroDto.Correo = maestro.Correo;
            maestroDto.Edad = maestro.Edad;
            maestroDto.MatriculaMaestro = maestro.MatriculaMaestro;

            return maestroDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MaestroDTO maestroDto)
        {
            var maestro = new Maestro();
            maestro.Nombres = maestroDto.Nombres;
            maestro.Apellidos = maestroDto.Apellidos;
            maestro.Correo = maestroDto.Correo;
            maestro.Edad = maestroDto.Edad;
            maestro.MatriculaMaestro = maestroDto.MatriculaMaestro;

            context.Maestros.Add(maestro);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] MaestroDTO maestroDto)
        {
            var maestroDb = await context.Maestros
                .FirstOrDefaultAsync(x => x.Id == maestroDto.Id);

            if (maestroDb == null)
            {
                return NotFound();
            }

            maestroDb.Nombres = maestroDto.Nombres;
            maestroDb.Apellidos = maestroDto.Apellidos;
            maestroDb.Correo = maestroDto.Correo;
            maestroDb.Edad = maestroDto.Edad;
            maestroDb.MatriculaMaestro = maestroDto.MatriculaMaestro;

            context.Maestros.Update(maestroDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var maestroDb = await context.Maestros
                .FirstOrDefaultAsync(x => x.Id == id);

            if (maestroDb == null)
            {
                return NotFound();
            }

            context.Maestros.Remove(maestroDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}