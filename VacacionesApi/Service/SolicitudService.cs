using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using VacacionesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class SolicitudService
    {
        private readonly ApplicationDbContext _context;

        public SolicitudService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Solicitud>> GetAllSolicitudesAsync()
        {
            return await _context.Solicitudes.ToListAsync();
        }

        public async Task<Solicitud> GetSolicitudByIdAsync(int id)
        {
            return await _context.Solicitudes.FindAsync(id);
        }

        public async Task<Solicitud> CreateSolicitudAsync(Solicitud solicitud)
        {
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
            return solicitud;
        }

        public async Task<Solicitud> UpdateSolicitudAsync(Solicitud solicitud)
        {
            _context.Solicitudes.Update(solicitud);
            await _context.SaveChangesAsync();
            return solicitud;
        }

        public async Task DeleteSolicitudAsync(int id)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud != null)
            {
                _context.Solicitudes.Remove(solicitud);
                await _context.SaveChangesAsync();
            }
        }
    }
}