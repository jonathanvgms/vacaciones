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

        // GET ALL
        public async Task<IEnumerable<UsuarioGetDTO>> GetAllAsync()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioGetDTO
                {
                    IdUsuario = u.IdUsuario,
                    Email = u.Email,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    IdRol = u.IdRol,
                    CreacionFecha = u.CreacionFecha,
                    CreacionUsuario = u.CreacionUsuario,
                    ModificacionFecha = u.ModificacionFecha,
                    ModificacionUsuario = u.ModificacionUsuario
                })
                .ToListAsync();
        }

        // GET BY ID
        public async Task<UsuarioGetDTO?> GetByIdAsync(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u == null) return null;

            return new UsuarioGetDTO
            {
                IdUsuario = u.IdUsuario,
                Email = u.Email,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                IdRol = u.IdRol,
                CreacionFecha = u.CreacionFecha,
                CreacionUsuario = u.CreacionUsuario,
                ModificacionFecha = u.ModificacionFecha,
                ModificacionUsuario = u.ModificacionUsuario
            };
        }

        // CREATE
        public async Task<UsuarioGetDTO> CreateAsync(UsuarioCreateDTO dto)
        {
            var entity = new Usuario
            {
                Email = dto.Email,
                Password = dto.Password,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                IdRol = dto.IdRol,
                CreacionFecha = DateTime.Now,
                CreacionUsuario = "sistema",
                ModificacionFecha = DateTime.Now,
                ModificacionUsuario = "sistema"
            };

            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();

            return new UsuarioGetDTO
            {
                IdUsuario = entity.IdUsuario,
                Email = entity.Email,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                IdRol = entity.IdRol,
                CreacionFecha = entity.CreacionFecha,
                CreacionUsuario = entity.CreacionUsuario
            };
        }

        // UPDATE
        public async Task<UsuarioGetDTO> UpdateAsync(int id, UsuarioUpdateDTO dto)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u == null) return null;

            u.Email = dto.Email;
            u.Nombre = dto.Nombre;
            u.Apellido = dto.Apellido;
            u.IdRol = dto.IdRol;
            u.ModificacionFecha = DateTime.Now;
            u.ModificacionUsuario = dto.ModificacionUsuario;

            await _context.SaveChangesAsync();
            return new UsuarioGetDTO
            {
                Email = u.Email,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                CreacionFecha = u.CreacionFecha,
                CreacionUsuario = u.CreacionUsuario,
                ModificacionFecha = u.CreacionFecha,
                ModificacionUsuario = u.ModificacionUsuario

            };
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u == null) return false;

            _context.Usuarios.Remove(u);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}