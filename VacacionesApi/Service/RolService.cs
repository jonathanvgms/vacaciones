using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using Microsoft.EntityFrameworkCore;
namespace VacacionesApi.Services
{
    public class RolService
    {
        private readonly VacacionesContext _context;

        public RolService(VacacionesContext context)
        {
            _context = context;
        }

        // ✅ Obtener todos los roles
        public async Task<List<RolDTO>> GetAllRolesAsync()
        {
            return await _context.Roles
                .Select(r => new RolDTO
                {
                    IdRol = r.IdRol,
                    Nombre = r.Nombre,
                    CreacionFecha = r.CreacionFecha,
                    CreacionUsuario = r.CreacionUsuario,
                    ModificacionFecha = r.ModificacionFecha,
                    ModificacionUsuario = r.ModificacionUsuario
                })
                .ToListAsync();
        }

        // ✅ Obtener un rol por ID
        public async Task<RolDTO?> GetRoleByIdAsync(int id)
        {
            return await _context.Roles
                .Where(r => r.IdRol == id)
                .Select(r => new RolDTO
                {
                    IdRol = r.IdRol,
                    Nombre = r.Nombre,
                    CreacionFecha = r.CreacionFecha,
                    CreacionUsuario = r.CreacionUsuario,
                    ModificacionFecha = r.ModificacionFecha,
                    ModificacionUsuario = r.ModificacionUsuario
                })
                .FirstOrDefaultAsync();
        }

        // ✅ Crear rol
        public async Task<RolDTO> CreateRoleAsync(RolDTO rolDto)
        {
            var rol = new Rol
            {
                Nombre = rolDto.Nombre,
                CreacionFecha = rolDto.CreacionFecha,
                CreacionUsuario = rolDto.CreacionUsuario,
                ModificacionFecha = rolDto.ModificacionFecha,
                ModificacionUsuario = rolDto.ModificacionUsuario
            };

            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();

            rolDto.IdRol = rol.IdRol;
            return rolDto;
        }

        // ✅ Actualizar rol
        public async Task<bool> UpdateRoleAsync(int id, RolDTO rolDto)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) return false;

            rol.Nombre = rolDto.Nombre;
            rol.ModificacionFecha = rolDto.ModificacionFecha;
            rol.ModificacionUsuario = rolDto.ModificacionUsuario;

            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Eliminar rol
        public async Task<bool> DeleteRoleAsync(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) return false;

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
