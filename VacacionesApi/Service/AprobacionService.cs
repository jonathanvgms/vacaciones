using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacacionesApi.Models;
using VacacionesApi.Data;
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

        // ✅ Obtener todas las aprobaciones
        public async Task<List<AprobacionDTO>> GetAllAprobacionesAsync()
        {
            return await _context.Aprobaciones
                .Include(a => a.IdAprobadorNavigation)
                .ThenInclude(e => e.IdUsuarioNavigation)
                .Include(a => a.IdSolicitudNavigation)
    .Select(a => new AprobacionDTO
    {
                    IdAprobacion = a.IdAprobacion,
                    IdSolicitud = a.IdSolicitud,
                    IdAprobador = a.IdAprobador,
                    Comentario = a.Comentario,
                    CreacionFecha = a.CreacionFecha,
                    CreacionUsaurio = a.CreacionUsaurio,
                    ModificacionFecha = a.ModificacionFecha,
                    ModificacionUsuario = a.ModificacionUsuario,
                    NombreAprobador = a.IdAprobadorNavigation.IdUsuarioNavigation.Nombre + " " +
                    a.IdAprobadorNavigation.IdUsuarioNavigation.Apellido,
                    SolicitudResumen = "Solicitud #" + a.IdSolicitudNavigation.IdSolicitud
    })
    .ToListAsync();
    }

        // ✅ Obtener una aprobación por ID
        public async Task<AprobacionDTO?> GetAprobacionByIdAsync(int id)
        {
return await _context.Aprobaciones
    .Include(a => a.IdAprobadorNavigation)
        .ThenInclude(e => e.IdUsuarioNavigation)
    .Include(a => a.IdSolicitudNavigation)
    .Where(a => a.IdAprobacion == id)
    .Select(a => new AprobacionDTO
    {
                    IdAprobacion = a.IdAprobacion,
                    IdSolicitud = a.IdSolicitud,
                    IdAprobador = a.IdAprobador,
                    Comentario = a.Comentario,
                    CreacionFecha = a.CreacionFecha,
                    CreacionUsaurio = a.CreacionUsaurio,
                    ModificacionFecha = a.ModificacionFecha,
                    ModificacionUsuario = a.ModificacionUsuario,
                    NombreAprobador = a.IdAprobadorNavigation.IdUsuarioNavigation.Nombre + " " +
                    a.IdAprobadorNavigation.IdUsuarioNavigation.Apellido,
                    SolicitudResumen = "Solicitud #" + a.IdSolicitudNavigation.IdSolicitud
    })
    .FirstOrDefaultAsync();
    }


        // ✅ Crear nueva aprobación
        public async Task<AprobacionDTO> CreateAprobacionAsync(AprobacionDTO dto)
        {
            var aprobacion = new Aprobacion
            {
                IdSolicitud = dto.IdSolicitud,
                IdAprobador = dto.IdAprobador,
                Comentario = dto.Comentario,
                CreacionFecha = dto.CreacionFecha,
                CreacionUsaurio = dto.CreacionUsaurio,
                ModificacionFecha = dto.ModificacionFecha,
                ModificacionUsuario = dto.ModificacionUsuario
            };

            _context.Aprobaciones.Add(aprobacion);
            await _context.SaveChangesAsync();

            dto.IdAprobacion = aprobacion.IdAprobacion;
            return dto;
        }

        // ✅ Actualizar aprobación existente
        public async Task<bool> UpdateAprobacionAsync(int id, AprobacionDTO dto)
        {
            var aprobacion = await _context.Aprobaciones.FindAsync(id);
            if (aprobacion == null)
                return false;

            aprobacion.IdSolicitud = dto.IdSolicitud;
            aprobacion.IdAprobador = dto.IdAprobador;
            aprobacion.Comentario = dto.Comentario;
            aprobacion.ModificacionFecha = dto.ModificacionFecha;
            aprobacion.ModificacionUsuario = dto.ModificacionUsuario;

            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Eliminar aprobación
        public async Task<bool> DeleteAprobacionAsync(int id)
        {
            var aprobacion = await _context.Aprobaciones.FindAsync(id);
            if (aprobacion == null)
                return false;

            _context.Aprobaciones.Remove(aprobacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
