using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using VacacionesApi.Data;
using Microsoft.EntityFrameworkCore;

    
namespace VacacionesApi.Services
{
    public class AprobacionService
    {
        private readonly VacacionesContext _context;

        public AprobacionService(VacacionesContext context)
        {
            _context = context;
        }

        public async Task<List<Aprobacion>> GetAllAprobacionesAsync()
        {
            return await _context.Aprobaciones.ToListAsync();
        }

        public async Task<Aprobacion> GetAprobacionByIdAsync(int id)
        {
            return await _context.Aprobaciones.FindAsync(id);
        }

        public async Task<Aprobacion> CreateAprobacionAsync(Aprobacion aprobacion)
        {
            _context.Aprobaciones.Add(aprobacion);
            await _context.SaveChangesAsync();
            return aprobacion;
        }

        public async Task<Aprobacion> UpdateAprobacionAsync(Aprobacion aprobacion)
        {
            _context.Aprobaciones.Update(aprobacion);
            await _context.SaveChangesAsync();
            return aprobacion;
        }

        public async Task DeleteAprobacionAsync(int id)
        {
            var aprobacion = await _context.Aprobaciones.FindAsync(id);
            if (aprobacion != null)
            {
                _context.Aprobaciones.Remove(aprobacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}