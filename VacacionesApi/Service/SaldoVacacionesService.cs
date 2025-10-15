using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using VacacionesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class SaldoVacacionesService
    {
        private readonly ApplicationDbContext _context;

        public SaldoVacacionesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaldoVacacione>> GetAllAsync()
        {
            return await _context.SaldosVacaciones.ToListAsync();
        }

        public async Task<SaldoVacacione> GetByIdAsync(int id)
        {
            return await _context.SaldosVacaciones.FindAsync(id);
        }

        public async Task<SaldoVacacione> CreateAsync(SaldoVacacione saldoVacaciones)
        {
            _context.SaldosVacaciones.Add(saldoVacaciones);
            await _context.SaveChangesAsync();
            return saldoVacaciones;
        }

        public async Task<SaldoVacacione> UpdateAsync(SaldoVacacione saldoVacaciones)
        {
            _context.SaldosVacaciones.Update(saldoVacaciones);
            await _context.SaveChangesAsync();
            return saldoVacaciones;
        }

        public async Task DeleteAsync(int id)
        {
            var saldoVacaciones = await _context.SaldosVacaciones.FindAsync(id);
            if (saldoVacaciones != null)
            {
                _context.SaldosVacaciones.Remove(saldoVacaciones);
                await _context.SaveChangesAsync();
            }
        }
    }
}