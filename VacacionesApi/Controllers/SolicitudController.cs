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

        // ✅ GET: api/Solicitud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudDto>>> GetAll()
        {
            var solicitudes = await _service.GetAllAsync();
            return Ok(solicitudes);
        }

        // ✅ GET: api/Solicitud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudDto>> GetById(int id)
        {
            var solicitud = await _service.GetByIdAsync(id);
            if (solicitud == null)
                return NotFound();

            return Ok(solicitud);
        }

        // ✅ POST: api/Solicitud
        [HttpPost]
        public async Task<ActionResult<Solicitud>> Create(SolicitudCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdSolicitud }, created);
        }

        // ✅ PUT: api/Solicitud/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SolicitudUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // ✅ DELETE: api/Solicitud/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
