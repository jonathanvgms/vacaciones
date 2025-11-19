using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;
using VacacionesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly SolicitudService _service;

        public SolicitudController(SolicitudService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudGetDTO>>> GetSolicitudes()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudInfoDTO>> GetSolicitud(int id)
        {
            var sol = await _service.GetByIdAsync(id);
            if (sol == null) return NotFound();

            return Ok(sol);
        }

        // CREATE
        [HttpPost]
        public async Task<ActionResult<SolicitudInfoDTO>> CreateSolicitud([FromBody] SolicitudCreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetSolicitud), new { id = created.IdSolicitud }, created);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSolicitud(int id, [FromBody] SolicitudUpdateDTO dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            if (!ok) return NotFound();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();

            return NoContent();
        }
    }
}
