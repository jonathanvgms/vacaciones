using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class FeriadoService
    {
        private readonly VacacionesContext _context;

        public FeriadoService(VacacionesContext context)
        {
            _context = context;
        }

        public async Task<List<Feriado>> GetAllFeriadosAsync()
        {
            return await _context.Feriados.ToListAsync();
        }

        public async Task<Feriado> GetFeriadoByIdAsync(int id)
        {
            return await _context.Feriados.FindAsync(id);
        }

        public async Task<Feriado> CreateFeriadoAsync(Feriado feriado)
        {
            _context.Feriados.Add(feriado);
            await _context.SaveChangesAsync();
            return feriado;
        }

        public async Task<Feriado> UpdateFeriadoAsync(Feriado feriado)
        {
            _context.Feriados.Update(feriado);
            await _context.SaveChangesAsync();
            return feriado;
        }

        public async Task DeleteFeriadoAsync(int id)
        {
            var feriado = await _context.Feriados.FindAsync(id);
            if (feriado != null)
            {
                _context.Feriados.Remove(feriado);
                await _context.SaveChangesAsync();
            }
        }
    }
}