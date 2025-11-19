using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacacionesApi.Models;
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

        // ============================
        // GET ALL
        // ============================
        public async Task<IEnumerable<AprobacionGetDTO>> GetAllAsync()
        {
            return await _context.Aprobaciones
                .Include(a => a.IdAprobadorNavigation)
                    .ThenInclude(e => e.IdUsuarioNavigation)
                .Select(a => new AprobacionGetDTO
                {
                    IdAprobacion = a.IdAprobacion,
                    IdSolicitud = a.IdSolicitud,
                    IdAprobador = a.IdAprobador,
                    NombreAprobador = a.IdAprobadorNavigation.IdUsuarioNavigation.Nombre,
                    ApellidoAprobador = a.IdAprobadorNavigation.IdUsuarioNavigation.Apellido,
                    Comentario = a.Comentario,
                    CreacionFecha = a.CreacionFecha
                })
                .ToListAsync();
        }

        // ============================
        // GET BY ID
        // ============================
        public async Task<AprobacionGetDTO?> GetByIdAsync(int id)
        {
            return await _context.Aprobaciones
                .Include(a => a.IdAprobadorNavigation)
                    .ThenInclude(e => e.IdUsuarioNavigation)
                .Where(a => a.IdAprobacion == id)
                .Select(a => new AprobacionGetDTO
                {
                    IdAprobacion = a.IdAprobacion,
                    IdSolicitud = a.IdSolicitud,
                    IdAprobador = a.IdAprobador,
                    NombreAprobador = a.IdAprobadorNavigation.IdUsuarioNavigation.Nombre,
                    ApellidoAprobador = a.IdAprobadorNavigation.IdUsuarioNavigation.Apellido,
                    Comentario = a.Comentario,
                    CreacionFecha = a.CreacionFecha
                })
                .FirstOrDefaultAsync();
        }

        // ============================
        // CREATE
        // ============================
        public async Task<AprobacionGetDTO> CreateAsync(AprobacionCreateDTO dto)
        {
            var aprobacion = new Aprobacion
            {
                IdSolicitud = dto.IdSolicitud,
                IdAprobador = dto.IdAprobador,
                Comentario = dto.Comentario,
                CreacionFecha = DateTime.Now,
                CreacionUsaurio = "Sistema"
            };

            _context.Aprobaciones.Add(aprobacion);
            await _context.SaveChangesAsync();

            var empleado = await _context.Empleados
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(e => e.IdEmpleado == dto.IdAprobador);

            return new AprobacionGetDTO
            {
                IdAprobacion = aprobacion.IdAprobacion,
                IdSolicitud = aprobacion.IdSolicitud,
                IdAprobador = aprobacion.IdAprobador,
                NombreAprobador = empleado?.IdUsuarioNavigation.Nombre,
                ApellidoAprobador = empleado?.IdUsuarioNavigation.Apellido,
                Comentario = aprobacion.Comentario,
                CreacionFecha = aprobacion.CreacionFecha
            };
        }

        // ============================
        // UPDATE
        // ============================
        public async Task<bool> UpdateAsync(int id, AprobacionUpdateDTO dto)
        {
            var aprobacion = await _context.Aprobaciones.FindAsync(id);
            if (aprobacion == null) return false;

            aprobacion.Comentario = dto.Comentario;
            aprobacion.ModificacionFecha = DateTime.Now;
            aprobacion.ModificacionUsuario = "Sistema";

            await _context.SaveChangesAsync();
            return true;
        }

        // ============================
        // DELETE
        // ============================
        public async Task<bool> DeleteAsync(int id)
        {
            var aprobacion = await _context.Aprobaciones.FindAsync(id);
            if (aprobacion == null) return false;

            _context.Aprobaciones.Remove(aprobacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}