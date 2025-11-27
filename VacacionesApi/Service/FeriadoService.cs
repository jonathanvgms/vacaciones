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

        // GET ALL
        public async Task<IEnumerable<FeriadoGetDTO>> GetAllAsync()
        {
            return await _context.Feriados
                .Select(f => new FeriadoGetDTO
                {
                    IdFeriado = f.IdFeriado,
                    Fecha = f.Fecha,
                    Descripcion = f.Descripcion,
                    Pais = f.Pais,
                    IdAmbito = f.IdAmbito
                })
                .ToListAsync();
        }

        // GET BY ID
        public async Task<FeriadoGetDTO?> GetByIdAsync(int id)
        {
            return await _context.Feriados
                .Where(f => f.IdFeriado == id)
                .Select(f => new FeriadoGetDTO
                {
                    IdFeriado = f.IdFeriado,
                    Fecha = f.Fecha,
                    Descripcion = f.Descripcion,
                    Pais = f.Pais,
                    IdAmbito = f.IdAmbito
                })
                .FirstOrDefaultAsync();
        }

        // CREATE
        public async Task<FeriadoGetDTO> CreateAsync(FeriadoCreateDTO dto)
        {
            var nuevo = new Feriado
            {
                Fecha = dto.Fecha,
                IdAmbito = dto.IdAmbito,
                Descripcion = dto.Descripcion,
                Pais = dto.Pais,
                CreacionFecha = DateTime.Now,
                CreacionUsuario = "system"
            };

            _context.Feriados.Add(nuevo);
            await _context.SaveChangesAsync();

            return new FeriadoGetDTO
            {
                IdFeriado = nuevo.IdFeriado,
                Fecha = nuevo.Fecha,
                Descripcion = nuevo.Descripcion,
                Pais = nuevo.Pais,
                IdAmbito = nuevo.IdAmbito
            };
        }

        // UPDATE
        public async Task<bool> UpdateAsync(int id, FeriadoUpdateDTO dto)
        {
            var feriado = await _context.Feriados.FindAsync(id);
            if (feriado == null)
                return false;

            feriado.Fecha = dto.Fecha;
            feriado.IdAmbito = dto.IdAmbito;
            feriado.Descripcion = dto.Descripcion;
            feriado.Pais = dto.Pais;
            feriado.ModificacionFecha = DateTime.Now;
            feriado.ModificacionUsuario = "system";

            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var feriado = await _context.Feriados.FindAsync(id);
            if (feriado == null)
                return false;

            _context.Feriados.Remove(feriado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}