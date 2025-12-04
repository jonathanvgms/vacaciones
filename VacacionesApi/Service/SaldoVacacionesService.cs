using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacacionesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class SaldoVacacioneService
    {
        private readonly VacacionesContext _context;

        public SaldoVacacioneService(VacacionesContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<IEnumerable<SaldoVacacioneDTO>> GetAllAsync()
        {
            return await _context.SaldoVacaciones
                .Select(s => new SaldoVacacioneDTO
                {
                    IdSaldo = s.IdSaldo,
                    IdEmpleado = s.IdEmpleado,
                    Anio = s.Anio,
                    DiasAsignados = s.DiasAsignados,
                    DiasTomados = s.DiasTomados,
                    DiasPendientes = s.DiasPendientes
                })
                .ToListAsync();
        }

        // GET BY ID
        public async Task<SaldoVacacioneDTO?> GetByIdAsync(int id)
        {
            var saldo = await _context.SaldoVacaciones.FindAsync(id);

            if (saldo == null) return null;

            return new SaldoVacacioneDTO
            {
                IdSaldo = saldo.IdSaldo,
                IdEmpleado = saldo.IdEmpleado,
                Anio = saldo.Anio,
                DiasAsignados = saldo.DiasAsignados,
                DiasTomados = saldo.DiasTomados,
                DiasPendientes = saldo.DiasPendientes
            };
        }

        // CREATE
        public async Task<SaldoVacacioneDTO> CreateAsync(SaldoVacacioneCreateDTO dto)
        {
            var saldo = new SaldoVacacione
            {
                IdEmpleado = dto.IdEmpleado,
                Anio = dto.Anio,
                DiasAsignados = dto.DiasAsignados,
                DiasTomados = dto.DiasTomados,
                DiasPendientes = dto.DiasAsignados - dto.DiasTomados,
                CreacionFecha = DateTime.Now,
                CreacionUsuario = "admin",
                ModificacionFecha = DateTime.Now,
                ModificacionUsuario = "sistema"
            };

            _context.SaldoVacaciones.Add(saldo);
            await _context.SaveChangesAsync();

            return new SaldoVacacioneDTO
            {
                IdSaldo = saldo.IdSaldo,
                IdEmpleado = saldo.IdEmpleado,
                Anio = saldo.Anio,
                DiasAsignados = saldo.DiasAsignados,
                DiasTomados = saldo.DiasTomados,
                DiasPendientes = saldo.DiasPendientes
            };
        }

        // UPDATE
        public async Task<bool> UpdateAsync(int id, SaldoVacacioneUpdateDTO dto)
        {
            var saldo = await _context.SaldoVacaciones.FindAsync(id);
            if (saldo == null) return false;

            saldo.DiasAsignados = dto.DiasAsignados;
            saldo.DiasTomados = dto.DiasTomados;
            saldo.DiasPendientes = dto.DiasAsignados - dto.DiasTomados;
            saldo.ModificacionFecha = DateTime.Now;
            saldo.ModificacionUsuario = "admin";

            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var saldo = await _context.SaldoVacaciones.FindAsync(id);
            if (saldo == null) return false;

            _context.SaldoVacaciones.Remove(saldo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}