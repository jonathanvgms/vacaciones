using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacacionesApi.Models;

using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class SolicitudService
    {
        private readonly VacacionesContext _context;

        public SolicitudService(VacacionesContext context)
        {
            _context = context;
        }

        // ✅ Obtener todas las solicitudes
        public async Task<List<SolicitudDto>> GetAllAsync()
        {
            return await _context.Solicitudes
                .Include(s => s.IdEmpleadoNavigation)
                    .ThenInclude(e => e.IdUsuarioNavigation)
                .Include(s => s.IdEstadoNavigation)
                .Select(s => new SolicitudDto
                {
                    IdSolicitud = s.IdSolicitud,
                    IdEmpleado = s.IdEmpleado,
                    NombreEmpleado = s.IdEmpleadoNavigation.IdUsuarioNavigation.Nombre,
                    FechaInicio = s.FechaInicio,
                    FechaFin = s.FechaFin,
                    DiasSolicitados = s.DiasSolicitados,
                    Estado = s.IdEstadoNavigation.Nombre,
                    Motivo = s.Motivo,
                    FechaCreacion = s.FechaCreacion,
                    CreacionUsuario = s.CreacionUsuario
                })
                .ToListAsync();
        }

        // ✅ Obtener una solicitud por ID
        public async Task<SolicitudDto?> GetByIdAsync(int id)
        {
            var s = await _context.Solicitudes
                .Include(s => s.IdEmpleadoNavigation)
                    .ThenInclude(e => e.IdUsuarioNavigation)
                .Include(s => s.IdEstadoNavigation)
                .FirstOrDefaultAsync(s => s.IdSolicitud == id);

            if (s == null) return null;

            return new SolicitudDto
            {
                IdSolicitud = s.IdSolicitud,
                IdEmpleado = s.IdEmpleado,
                NombreEmpleado = s.IdEmpleadoNavigation.IdUsuarioNavigation.Nombre,
                FechaInicio = s.FechaInicio,
                FechaFin = s.FechaFin,
                DiasSolicitados = s.DiasSolicitados,
                Estado = s.IdEstadoNavigation.Nombre,
                Motivo = s.Motivo,
                FechaCreacion = s.FechaCreacion,
                CreacionUsuario = s.CreacionUsuario
            };
        }

        // ✅ Crear una nueva solicitud
        public async Task<Solicitud> CreateAsync(SolicitudCreateDto dto)
        {
            var solicitud = new Solicitud
            {
                IdEmpleado = dto.IdEmpleado,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                DiasSolicitados = dto.DiasSolicitados,
                IdEstado = dto.IdEstado,
                Motivo = dto.Motivo,
                FechaCreacion = DateTime.Now,
                CreacionUsuario = dto.CreacionUsuario
            };

            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
            return solicitud;
        }

        // ✅ Actualizar solicitud existente
        public async Task<bool> UpdateAsync(int id, SolicitudUpdateDto dto)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null) return false;

            solicitud.FechaInicio = dto.FechaInicio;
            solicitud.FechaFin = dto.FechaFin;
            solicitud.DiasSolicitados = dto.DiasSolicitados;
            solicitud.IdEstado = dto.IdEstado;
            solicitud.Motivo = dto.Motivo;

            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Eliminar solicitud
        public async Task<bool> DeleteAsync(int id)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null) return false;

            _context.Solicitudes.Remove(solicitud);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
