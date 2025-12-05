using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services;

public class AmbitoFeriadoService
    {
        private readonly VacacionesContext _context;

        public AmbitoFeriadoService(VacacionesContext context)
        {
            _context = context;
        }

        public async Task<List<AmbitoFeriadoGetDTO>> GetAll()
        {
            return await _context.AmbitoFeriados
                .Select(a => new AmbitoFeriadoGetDTO
                {
                    IdAmbito = a.IdAmbito,
                    Nombre = a.Nombre
                })
                .ToListAsync();
        }

        public async Task<AmbitoFeriadoGetDTO?> GetById(int id)
        {
            return await _context.AmbitoFeriados
                .Where(a => a.IdAmbito == id)
                .Select(a => new AmbitoFeriadoGetDTO
                {
                    IdAmbito = a.IdAmbito,
                    Nombre = a.Nombre
                })
                .FirstOrDefaultAsync();
        }

        public async Task<AmbitoFeriado> Create(AmbitoFeriadoCreateDTO dto)
        {
            var entidad = new AmbitoFeriado
            {
                Nombre = dto.Nombre,
                CreacionFecha = DateTime.Now,
                CreacionUsuario = "system",
                ModificaionFecha = DateTime.Now,
                ModificacionUsuario = "sistema"
            };

            _context.AmbitoFeriados.Add(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<AmbitoFeriadoGetDTO> Update(int id, AmbitoFeriadoUpdateDTO dto)
        {
            var ambito = await _context.AmbitoFeriados.FindAsync(id);

            if (ambito == null)
                return null;

            ambito.Nombre = dto.Nombre;
            ambito.ModificaionFecha = DateTime.Now;
            ambito.ModificacionUsuario = "system";

            await _context.SaveChangesAsync();
            return new AmbitoFeriadoGetDTO
            {
              Nombre = ambito.Nombre,
              IdAmbito = ambito.IdAmbito,
                
            };
        }

        public async Task<bool> Delete(int id)
        {
            var ambito = await _context.AmbitoFeriados.FindAsync(id);

            if (ambito == null)
                return false;

            _context.AmbitoFeriados.Remove(ambito);
            await _context.SaveChangesAsync();
            return true;
        }
    }
