using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly SolicitudService _solicitudService;

        public SolicitudController(SolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }

        // GET: api/solicitud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicitudes()
        {
            var solicitudes = await _solicitudService.GetAllSolicitudesAsync();
            return Ok(solicitudes);
        }

        // GET: api/solicitud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {
            var solicitud = await _solicitudService.GetSolicitudByIdAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return Ok(solicitud);
        }

        // POST: api/solicitud
        [HttpPost]
        public async Task<ActionResult<Solicitud>> CreateSolicitud([FromBody] SolicitudCreateUpdateDto solicitudDto)    
        {
        var nuevaSolicitud = await _solicitudService.CreateSolicitudAsync(solicitudDto);
        return CreatedAtAction(nameof(GetSolicitud), new { id = nuevaSolicitud.IdSolicitud }, nuevaSolicitud);
        }

        // PUT: api/solicitud/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSolicitud(int id, [FromBody] SolicitudCreateUpdateDto solicitudDto)
    {
        var existente = await _solicitudService.GetSolicitudByIdAsync(id);
        if (existente == null)
        {
        return NotFound();
        }

        await _solicitudService.UpdateSolicitudAsync(id, solicitudDto);
        return NoContent();
    }

        // DELETE: api/solicitud/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int id)
        {
            var solicitud = await _solicitudService.GetSolicitudByIdAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            await _solicitudService.DeleteSolicitudAsync(id);
            return NoContent();
        }
    }
}
