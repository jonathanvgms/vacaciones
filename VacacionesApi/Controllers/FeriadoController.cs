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
        private readonly FeriadoService _service;

        public FeriadoController(FeriadoService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeriadoGetDTO>>> GetFeriados()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<FeriadoGetDTO>> GetFeriado(int id)
        {
            var feriado = await _service.GetByIdAsync(id);
            if (feriado == null) return NotFound();
            return Ok(feriado);
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FeriadoCreateDTO dto)
        {
            if (dto == null) return BadRequest("Datos inválidos.");

            var creado = await _service.CreateAsync(dto);
            return Ok(creado);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FeriadoUpdateDTO dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            if (!ok) return NotFound();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();

            return NoContent();
        }
    }
}