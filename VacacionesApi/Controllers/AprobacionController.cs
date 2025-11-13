using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AprobacionController : ControllerBase
    {
        private readonly AprobacionService _aprobacionService;

        public AprobacionController(AprobacionService aprobacionService)
        {
            _aprobacionService = aprobacionService;
        }

        // GET: api/aprobacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AprobacionDTO>>> GetAll()
        {
            var aprobaciones = await _aprobacionService.GetAllAprobacionesAsync();
            return Ok(aprobaciones);
        }

        // GET: api/aprobacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AprobacionDTO>> GetById(int id)
        {
            var aprobacion = await _aprobacionService.GetAprobacionByIdAsync(id);
            if (aprobacion == null)
                return NotFound();

            return Ok(aprobacion);
        }

        // POST: api/aprobacion
        [HttpPost]
        public async Task<ActionResult<AprobacionDTO>> Create([FromBody] AprobacionDTO dto)
        {
            var created = await _aprobacionService.CreateAprobacionAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdAprobacion }, created);
        }

        // PUT: api/aprobacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AprobacionDTO dto)
        {
            var updated = await _aprobacionService.UpdateAprobacionAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/aprobacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _aprobacionService.DeleteAprobacionAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
