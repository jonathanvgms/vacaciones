using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacacionesApi.Models;
using VacacionesApi.Data;

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

        // Obtener todas las solicitudes
        public async Task<List<SolicitudDto>> GetAllSolicitudesAsync()
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

        // Obtener por ID
        public async Task<SolicitudDto?> GetSolicitudByIdAsync(int id)
        {
            var s = await _context.Solicitudes
                .Include(s => s.IdEmpleadoNavigation)
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

        // Crear nueva solicitud
        public async Task<Solicitud> CreateSolicitudAsync(SolicitudCreateUpdateDto dto)
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

        // Actualizar solicitud
        public async Task<Solicitud?> UpdateSolicitudAsync(int id, SolicitudCreateUpdateDto dto)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null) return null;

            solicitud.IdEmpleado = dto.IdEmpleado;
            solicitud.FechaInicio = dto.FechaInicio;
            solicitud.FechaFin = dto.FechaFin;
            solicitud.DiasSolicitados = dto.DiasSolicitados;
            solicitud.IdEstado = dto.IdEstado;
            solicitud.Motivo = dto.Motivo;
            solicitud.CreacionUsuario = dto.CreacionUsuario;

            await _context.SaveChangesAsync();
            return solicitud;
        }

        public async Task DeleteSolicitudAsync(int id)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud != null)
            {
                _context.Solicitudes.Remove(solicitud);
                await _context.SaveChangesAsync();
            }
        }

        internal async Task CreateSolicitudAsync(Solicitud solicitud)
        {
            throw new NotImplementedException();
        }
    }
}