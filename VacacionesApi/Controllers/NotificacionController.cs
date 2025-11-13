using Microsoft.AspNetCore.Mvc;

using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private readonly NotificacionService _notificacionService;

        public NotificacionController(NotificacionService notificacionService)
        {
            _notificacionService = notificacionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificacionDTO>>> GetNotificaciones()
        {
            var notificaciones = await _notificacionService.GetAllNotificacionesAsync();
            return Ok(notificaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificacionDTO>> GetNotificacion(int id)
        {
            var notificacion = await _notificacionService.GetNotificacionByIdAsync(id);
            if (notificacion == null)
            return NotFound();

            return Ok(notificacion);
        }

        [HttpPost]
        public async Task<ActionResult<NotificacionDTO>> CreateNotificacion(NotificacionDTO notificacionDto)
        {
            var created = await _notificacionService.CreateNotificacionAsync(notificacionDto);
            return CreatedAtAction(nameof(GetNotificacion), new { id = created.IdNotificacion }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificacion(int id, NotificacionDTO notificacionDto)
        {
            if (id != notificacionDto.IdNotificacion)
                return BadRequest();
            var updated = await _notificacionService.UpdateNotificacionAsync(id, notificacionDto);
            if (!updated)
            return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var deleted = await _notificacionService.DeleteNotificacionAsync(id);
            if (!deleted)
            return NotFound();
            return NoContent();
        }
    }
}
