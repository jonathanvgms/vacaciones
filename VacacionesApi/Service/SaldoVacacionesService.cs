using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacacionesApi.Models;
using VacacionesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class SaldoVacacionesService
    {
        private readonly VacacionesContext _context;

        public SaldoVacacionesService(VacacionesContext context)
        {
            _context = context;
        }

        // ✅ Obtener todos
        public async Task<List<SaldoVacacionesDTO>> GetAllAsync()
        {
            return await _context.SaldosVacaciones
                .Select(s => new SaldoVacacionesDTO
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

        // ✅ Obtener por Id
        public async Task<SaldoVacacionesDTO?> GetByIdAsync(int id)
        {
            var s = await _context.SaldosVacaciones.FindAsync(id);
            if (s == null) return null;

            return new SaldoVacacionesDTO
            {
                IdSaldo = s.IdSaldo,
                IdEmpleado = s.IdEmpleado,
                Anio = s.Anio,
                DiasAsignados = s.DiasAsignados,
                DiasTomados = s.DiasTomados,
                DiasPendientes = s.DiasPendientes
            };
        }

        // ✅ Crear
        public async Task<SaldoVacacionesDTO> CreateAsync(SaldoVacacionesCreateDTO dto)
        {
            var saldo = new SaldoVacacione
            {
                IdEmpleado = dto.IdEmpleado,
                Anio = dto.Anio,
                DiasAsignados = dto.DiasAsignados,
                DiasTomados = dto.DiasTomados,
                DiasPendientes = dto.DiasPendientes,
                CreacionFecha = DateTime.Now,
                CreacionUsuario = "admin"
            };

            _context.SaldosVacaciones.Add(saldo);
            await _context.SaveChangesAsync();

            return new SaldoVacacionesDTO
            {
                IdSaldo = saldo.IdSaldo,
                IdEmpleado = saldo.IdEmpleado,
                Anio = saldo.Anio,
                DiasAsignados = saldo.DiasAsignados,
                DiasTomados = saldo.DiasTomados,
                DiasPendientes = saldo.DiasPendientes
            };
        }

        // ✅ Actualizar
        public async Task<bool> UpdateAsync(int id, SaldoVacacionesUpdateDTO dto)
        {
            var saldo = await _context.SaldosVacaciones.FindAsync(id);
            if (saldo == null)
                return false;

            saldo.Anio = dto.Anio;
            saldo.DiasAsignados = dto.DiasAsignados;
            saldo.DiasTomados = dto.DiasTomados;
            saldo.DiasPendientes = dto.DiasPendientes;
            saldo.ModificacionFecha = DateTime.Now;
            saldo.ModificacionUsuario = "admin";

            _context.SaldosVacaciones.Update(saldo);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Eliminar
        public async Task<bool> DeleteAsync(int id)
        {
            var saldo = await _context.SaldosVacaciones.FindAsync(id);
            if (saldo == null)
                return false;

            _context.SaldosVacaciones.Remove(saldo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
