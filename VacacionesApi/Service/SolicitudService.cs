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

        // ============================
        // GET ALL
        // ============================
        public async Task<IEnumerable<SolicitudGetDTO>> GetAllAsync()
        {
            return await _context.Solicitudes
                .Include(s => s.IdEmpleadoNavigation)
                .Include(s => s.IdEstadoNavigation)
                .Select(s => new SolicitudGetDTO
                {
                    IdSolicitud = s.IdSolicitud,
                    Empleado = s.IdEmpleadoNavigation.IdUsuarioNavigation.Nombre + " " +
                               s.IdEmpleadoNavigation.IdUsuarioNavigation.Apellido,
                    Estado = s.IdEstadoNavigation.Nombre,
                    DiasSolicitados = s.DiasSolicitados ?? 0
                })
                .ToListAsync();
        }

        // ============================
        // GET BY ID
        // ============================
        public async Task<SolicitudInfoDTO?> GetByIdAsync(int id)
        {
            return await _context.Solicitudes
                .Include(s => s.IdEmpleadoNavigation).ThenInclude(e => e.IdUsuarioNavigation)
                .Include(s => s.IdEstadoNavigation)
                .Where(s => s.IdSolicitud == id)
                .Select(s => new SolicitudInfoDTO
                {
                    IdSolicitud = s.IdSolicitud,
                    IdEmpleado = s.IdEmpleado,
                    NombreEmpleado = s.IdEmpleadoNavigation.IdUsuarioNavigation.Nombre,
                    ApellidoEmpleado = s.IdEmpleadoNavigation.IdUsuarioNavigation.Apellido,
                    FechaInicio = s.FechaInicio,
                    FechaFin = s.FechaFin,
                    DiasSolicitados = s.DiasSolicitados ?? 0,
                    Estado = s.IdEstadoNavigation.Nombre,
                    Motivo = s.Motivo,
                    FechaCreacion = s.FechaCreacion
                })
                .FirstOrDefaultAsync();
        }

        // ============================
        // CREATE
        // ============================
        public async Task<SolicitudInfoDTO> CreateAsync(SolicitudCreateDTO dto)
        {
            int dias = dto.FechaFin.DayNumber - dto.FechaInicio.DayNumber;

            var solicitud = new Solicitud
            {
                IdEmpleado = dto.IdEmpleado,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                DiasSolicitados = dias,
                IdEstado = 1, // Estado inicial "Pendiente"
                Motivo = dto.Motivo,
                FechaCreacion = DateTime.UtcNow,
                CreacionUsuario = "system"
            };

            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();

            var empleado = await _context.Empleados
                .Include(e => e.IdUsuarioNavigation)
                .FirstAsync(e => e.IdEmpleado == dto.IdEmpleado);

            var estado = await _context.EstadoSolicituds
                .FindAsync(solicitud.IdEstado);

            return new SolicitudInfoDTO
            {
                IdSolicitud = solicitud.IdSolicitud,
                IdEmpleado = solicitud.IdEmpleado,
                NombreEmpleado = empleado.IdUsuarioNavigation.Nombre,
                ApellidoEmpleado = empleado.IdUsuarioNavigation.Apellido,
                FechaInicio = solicitud.FechaInicio,
                FechaFin = solicitud.FechaFin,
                DiasSolicitados = solicitud.DiasSolicitados ?? 0,
                Estado = estado!.Nombre,
                Motivo = solicitud.Motivo,
                FechaCreacion = solicitud.FechaCreacion
            };
        }

        // ============================
        // UPDATE
        // ============================
        public async Task<bool> UpdateAsync(int id, SolicitudUpdateDTO dto)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null) return false;

            solicitud.FechaInicio = dto.FechaInicio;
            solicitud.FechaFin = dto.FechaFin;
            solicitud.DiasSolicitados = dto.FechaFin.DayNumber - dto.FechaInicio.DayNumber;
            solicitud.Motivo = dto.Motivo;
            solicitud.IdEstado = dto.IdEstado;

            await _context.SaveChangesAsync();
            return true;
        }

        // ============================
        // DELETE
        // ============================
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