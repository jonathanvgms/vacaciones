using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aprobacion>>> GetAll()
        {
            var aprobaciones = await _aprobacionService.GetAllAprobacionesAsync();
            return Ok(aprobaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aprobacion>> GetById(int id)
        {
            var aprobacion = await _aprobacionService.GetAprobacionByIdAsync(id);
            if (aprobacion == null)
            {
                return NotFound();
            }
            return Ok(aprobacion);
        }

        [HttpPost]
        public async Task<ActionResult<Aprobacion>> Create(Aprobacion aprobacion)
        {
            var createdAprobacion = await _aprobacionService.CreateAprobacionAsync(aprobacion);
            return CreatedAtAction(nameof(GetById), new { id = createdAprobacion }, createdAprobacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Aprobacion aprobacion)
        {
            if (id != aprobacion.IdAprobacion)
            {
                return BadRequest();
            }

            var existingAprobacion = await _aprobacionService.GetAprobacionByIdAsync(id);
            if (existingAprobacion == null)
            {
                return NotFound();
            }

            await _aprobacionService.UpdateAprobacionAsync(aprobacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aprobacion = await _aprobacionService.GetAprobacionByIdAsync(id);
            if (aprobacion == null)
            {
                return NotFound();
            }

            await _aprobacionService.DeleteAprobacionAsync(id);
            return NoContent();
        }
    }
}
