using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacacionesApi.Models;
using Microsoft.EntityFrameworkCore; 

namespace VacacionesApi.Services
{
    public class EstadoSolicitudService
    {
        private readonly VacacionesContext _context;

        public EstadoSolicitudService(VacacionesContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<IEnumerable<EstadoSolicitudGetDTO>> GetAllAsync()
        {
            return await _context.EstadoSolicituds
                .Select(e => new EstadoSolicitudGetDTO
                {
                    IdEstado = e.IdEstado,
                    Nombre = e.Nombre
                })
                .ToListAsync();
        }

        // GET BY ID
        public async Task<EstadoSolicitudGetDTO?> GetByIdAsync(int id)
        {
            return await _context.EstadoSolicituds
                .Where(e => e.IdEstado == id)
                .Select(e => new EstadoSolicitudGetDTO
                {
                    IdEstado = e.IdEstado,
                    Nombre = e.Nombre
                })
                .FirstOrDefaultAsync();
        }

        // CREATE
        public async Task<EstadoSolicitudGetDTO> CreateAsync(EstadoSolicitudCreateDTO dto)
        {
            var estado = new EstadoSolicitud
            {
                Nombre = dto.Nombre
            };

            _context.EstadoSolicituds.Add(estado);
            await _context.SaveChangesAsync();

            return new EstadoSolicitudGetDTO
            {
                IdEstado = estado.IdEstado,
                Nombre = estado.Nombre
            };
        }

        // UPDATE
        public async Task<bool> UpdateAsync(int id, EstadoSolicitudUpdateDTO dto)
        {
            var estado = await _context.EstadoSolicituds.FindAsync(id);
            if (estado == null) return false;

            estado.Nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var estado = await _context.EstadoSolicituds.FindAsync(id);
            if (estado == null) return false;

            _context.EstadoSolicituds.Remove(estado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
