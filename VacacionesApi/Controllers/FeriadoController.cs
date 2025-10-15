using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeriadoController : ControllerBase
    {
        private readonly FeriadoService _feriadoService;

        public FeriadoController(FeriadoService feriadoService)
        {
            _feriadoService = feriadoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feriado>>> GetAll()
        {
            var feriados = await _feriadoService.GetAllFeriadosAsync();
            return Ok(feriados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feriado>> GetById(int id)
        {
            var feriado = await _feriadoService.GetFeriadoByIdAsync(id);
            if (feriado == null)
            {
                return NotFound();
            }
            return Ok(feriado);
        }

        [HttpPost]
        public async Task<ActionResult<Feriado>> Create(Feriado feriado)
        {
            var createdFeriado = await _feriadoService.CreateFeriadoAsync(feriado);
            return CreatedAtAction(nameof(GetById), new { id = createdFeriado.IdFeriado }, createdFeriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Feriado feriado)
        {
            if (id != feriado.IdFeriado)
            {
                return BadRequest();
            }

            var existingFeriado = await _feriadoService.GetFeriadoByIdAsync(id);
            if (existingFeriado == null)
            {
                return NotFound();
            }

            await _feriadoService.UpdateFeriadoAsync(feriado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingFeriado = await _feriadoService.GetFeriadoByIdAsync(id);
            if (existingFeriado == null)
            {
                return NotFound();
            }

            await _feriadoService.DeleteFeriadoAsync(id);
            return NoContent();
        }
    }
}
