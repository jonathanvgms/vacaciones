using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace VacacionesApi.Services
{
    public class RolService
    {
        private readonly VacacionesContext _context;

        public RolService(VacacionesContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<RolGetDTO>> GetAllRolesAsync()
        {
            return await _context.Roles
                .Select(r => new RolGetDTO
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

        // GET BY ID
        public async Task<RolInfoDTO?> GetRoleByIdAsync(int id)
        {
            return await _context.Roles
                .Where(r => r.IdRol == id)
                .Select(r => new RolInfoDTO
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

        // CREATE SOLO CON NOMBRE
       public async Task<RolGetDTO> CreateRoleAsync(RolCreateDTO dto)
{
    var nuevoRol = new Rol
    {
        Nombre = dto.Nombre,
        CreacionUsuario = "sistema",
        CreacionFecha = DateTime.Now,        
        ModificacionFecha = DateTime.Now,
        ModificacionUsuario = "sistema"
    };

    _context.Roles.Add(nuevoRol);
    await _context.SaveChangesAsync();

    return new RolGetDTO
    {
        IdRol = nuevoRol.IdRol,
        Nombre = nuevoRol.Nombre,
        CreacionFecha = nuevoRol.CreacionFecha,
        CreacionUsuario = nuevoRol.CreacionUsuario,
        ModificacionFecha = nuevoRol.ModificacionFecha,
        ModificacionUsuario = nuevoRol.ModificacionUsuario
    };
}


        // UPDATE
        public async Task<RolGetDTO> UpdateRoleAsync(int id, RolUpdateDTO dto)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) return null;

            rol.Nombre = dto.Nombre;
            rol.ModificacionFecha = DateTime.Now;
            rol.ModificacionUsuario = dto.ModificacionUsuario;

            await _context.SaveChangesAsync();

            return new RolGetDTO
            {
                IdRol = rol.IdRol,
                Nombre = rol.Nombre,
                CreacionFecha = rol.CreacionFecha,
                CreacionUsuario = rol.CreacionUsuario,
                ModificacionFecha = rol.ModificacionFecha,
                ModificacionUsuario = rol.ModificacionUsuario
            };
        }

        // DELETE
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
