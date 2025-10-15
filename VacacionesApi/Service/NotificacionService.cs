using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using VacacionesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class NotificacionService
    {
        private readonly ApplicationDbContext _context;

        public NotificacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notificacion>> GetAllNotificacionesAsync()
        {
            return await _context.Notificaciones.ToListAsync();
        }

        public async Task<Notificacion> GetNotificacionByIdAsync(int id)
        {
            return await _context.Notificaciones.FindAsync(id);
        }

        public async Task<Notificacion> CreateNotificacionAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();
            return notificacion;
        }

        public async Task<Notificacion> UpdateNotificacionAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Update(notificacion);
            await _context.SaveChangesAsync();
            return notificacion;
        }

        public async Task DeleteNotificacionAsync(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion != null)
            {
                _context.Notificaciones.Remove(notificacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}