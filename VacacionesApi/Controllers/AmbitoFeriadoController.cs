using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbitoFeriadoController : ControllerBase
    {
        private readonly AmbitoFeriadoService _service;

        public AmbitoFeriadoController(AmbitoFeriadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AmbitoFeriadoCreateDTO dto)
        {
            var entidad = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = entidad.IdAmbito }, entidad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AmbitoFeriadoUpdateDTO dto)
        {
            var actualizado = await _service.Update(id, dto);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.Delete(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}