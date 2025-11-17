using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacacionesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class NotificacionService
    {
        private readonly VacacionesContext _context;

        public NotificacionService(VacacionesContext context)
        {
            _context = context;
        }

        // ✅ Obtener todas las notificaciones
        public async Task<List<NotificacionDTO>> GetAllNotificacionesAsync()
        {
            return await _context.Notificaciones
                .Include(n => n.IdUsuarioNavigation)
                .Select(n => new NotificacionDTO
                {
                    IdNotificacion = n.IdNotificacion,
                    IdUsuario = n.IdUsuario,
                    Asunto = n.Asunto,
                    Mensaje = n.Mensaje,
                    Fecha = n.Fecha,
                    Leido = n.Leido,
                    CreacionFecha = n.CreacionFecha,
                    CreacionUsuario = n.CreacionUsuario,
                    ModificacionFecha = n.ModificacionFecha,
                    ModificacionUsuario = n.ModificacionUsuario,
                    NombreUsuario = n.IdUsuarioNavigation.Nombre + " " + n.IdUsuarioNavigation.Apellido
                })
                .ToListAsync();
        }

        // ✅ Obtener una notificación por ID
        public async Task<NotificacionDTO?> GetNotificacionByIdAsync(int id)
        {
            return await _context.Notificaciones
                .Include(n => n.IdUsuarioNavigation)
                .Where(n => n.IdNotificacion == id)
                .Select(n => new NotificacionDTO
                {
                    IdNotificacion = n.IdNotificacion,
                    IdUsuario = n.IdUsuario,
                    Asunto = n.Asunto,
                    Mensaje = n.Mensaje,
                    Fecha = n.Fecha,
                    Leido = n.Leido,
                    CreacionFecha = n.CreacionFecha,
                    CreacionUsuario = n.CreacionUsuario,
                    ModificacionFecha = n.ModificacionFecha,
                    ModificacionUsuario = n.ModificacionUsuario,
                    NombreUsuario = n.IdUsuarioNavigation.Nombre + " " + n.IdUsuarioNavigation.Apellido
                })
                .FirstOrDefaultAsync();
        }

        // ✅ Crear nueva notificación
        public async Task<NotificacionDTO> CreateNotificacionAsync(NotificacionDTO dto)
        {
            var notificacion = new Notificacion
            {
                IdUsuario = dto.IdUsuario,
                Asunto = dto.Asunto,
                Mensaje = dto.Mensaje,
                Fecha = dto.Fecha,
                Leido = dto.Leido,
                CreacionFecha = dto.CreacionFecha,
                CreacionUsuario = dto.CreacionUsuario,
                ModificacionFecha = dto.ModificacionFecha,
                ModificacionUsuario = dto.ModificacionUsuario
            };

            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();

            dto.IdNotificacion = notificacion.IdNotificacion;
            return dto;
        }

        // ✅ Actualizar notificación
        public async Task<bool> UpdateNotificacionAsync(int id, NotificacionDTO dto)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null)
                return false;

            notificacion.Asunto = dto.Asunto;
            notificacion.Mensaje = dto.Mensaje;
            notificacion.Leido = dto.Leido;
            notificacion.ModificacionFecha = dto.ModificacionFecha;
            notificacion.ModificacionUsuario = dto.ModificacionUsuario;

            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Eliminar notificación
        public async Task<bool> DeleteNotificacionAsync(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null)
                return false;

            _context.Notificaciones.Remove(notificacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
