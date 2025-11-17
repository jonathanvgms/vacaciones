using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VacacionesApi.Models;


namespace VacacionesApi.Services
{
    public class UsuarioService
    {
        private readonly VacacionesContext _context;

        public UsuarioService(VacacionesContext context)
        {
            _context = context;
        }

        // ✅ Obtener todos los usuarios
        public async Task<List<UsuarioDTO>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .Select(u => new UsuarioDTO
                {
                    IdUsuario = u.IdUsuario,
                    Email = u.Email,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    IdRol = u.IdRol,
                    RolNombre = u.IdRolNavigation.Nombre, // si existe en el modelo Rol
                    CreacionFecha = u.CreacionFecha,
                    CreacionUsuario = u.CreacionUsuario,
                    ModificacionFecha = u.ModificacionFecha,
                    ModificacionUsuario = u.ModificacionUsuario
                })
                .ToListAsync();
        }

        // ✅ Obtener usuario por ID
        public async Task<UsuarioDTO?> GetUsuarioByIdAsync(int id)
        {
            var u = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);

            if (u == null) return null;

            return new UsuarioDTO
            {
                IdUsuario = u.IdUsuario,
                Email = u.Email,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                IdRol = u.IdRol,
                RolNombre = u.IdRolNavigation.Nombre,
                CreacionFecha = u.CreacionFecha,
                CreacionUsuario = u.CreacionUsuario,
                ModificacionFecha = u.ModificacionFecha,
                ModificacionUsuario = u.ModificacionUsuario
            };
        }

        // ✅ Crear usuario
        public async Task<Usuario> CreateUsuarioAsync(UsuarioCreateDTO dto)
        {
            var usuario = new Usuario
            {
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                IdRol = dto.IdRol,
                CreacionFecha = DateTime.Now,
                CreacionUsuario = dto.CreacionUsuario
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        // ✅ Actualizar usuario
        public async Task<Usuario?> UpdateUsuarioAsync(UsuarioUpdateDTO dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null) return null;

            usuario.Email = dto.Email;
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.IdRol = dto.IdRol;
            usuario.ModificacionFecha = DateTime.Now;
            usuario.ModificacionUsuario = dto.ModificacionUsuario;

            await _context.SaveChangesAsync();
            return usuario;
        }

        // ✅ Eliminar usuario
        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
