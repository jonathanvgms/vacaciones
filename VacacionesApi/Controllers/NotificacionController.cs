using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
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
        public async Task<ActionResult<IEnumerable<Notificacion>>> GetNotificaciones()
        {
            var notificaciones = await _notificacionService.GetAllNotificacionesAsync();
            return Ok(notificaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacion>> GetNotificacion(int id)
        {
            var notificacion = await _notificacionService.GetNotificacionByIdAsync(id);
            if (notificacion == null)
            {
                return NotFound();
            }
            return Ok(notificacion);
        }

        [HttpPost]
        public async Task<ActionResult<Notificacion>> CreateNotificacion(Notificacion notificacion)
        {
            var createdNotificacion = await _notificacionService.CreateNotificacionAsync(notificacion);
            return CreatedAtAction(nameof(GetNotificacion), new { id = createdNotificacion }, createdNotificacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificacion(int id, Notificacion notificacion)
        {
            if (id != notificacion.IdNotificacion)
            {
                return BadRequest();
            }

            var existingNotificacion = await _notificacionService.GetNotificacionByIdAsync(id);
            if (existingNotificacion == null)
            {
                return NotFound();
            }

            await _notificacionService.UpdateNotificacionAsync(notificacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var existingNotificacion = await _notificacionService.GetNotificacionByIdAsync(id);
            if (existingNotificacion == null)
            {
                return NotFound();
            }

            await _notificacionService.DeleteNotificacionAsync(id);
            return NoContent();
        }
    }
}
