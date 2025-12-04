using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class EmpleadoService
    {
        private readonly VacacionesContext _context;

        public EmpleadoService(VacacionesContext context)
        {
            _context = context;
        }

        // ================================
        // GET ALL
        // ================================
        public async Task<IEnumerable<EmpleadoGetDTO>> GetAllAsync()
        {
            return await _context.Empleados
                .Include(e => e.IdUsuarioNavigation)
                .Select(e => new EmpleadoGetDTO
                {
                    IdEmpleado = e.IdEmpleado,
                    Nombre = e.IdUsuarioNavigation.Nombre,
                    Apellido = e.IdUsuarioNavigation.Apellido
                })
                .ToListAsync();
        }

        // ================================
        // GET BY ID
        // ================================
        public async Task<EmpleadoInfoDTO> GetByIdAsync(int id)
        {
            return await _context.Empleados
                .Include(e => e.IdUsuarioNavigation)
                .Where(e => e.IdEmpleado == id)
                .Select(e => new EmpleadoInfoDTO
                {
                    IdEmpleado = e.IdEmpleado,
                    Nombre = e.IdUsuarioNavigation.Nombre,
                    Apellido = e.IdUsuarioNavigation.Apellido,
                    Email = e.IdUsuarioNavigation.Email,
                    IdRol = e.IdUsuarioNavigation.IdRol,
                    Cargo = e.Cargo,
                    IdDepartamento = e.IdDepartamento
                })
                .FirstOrDefaultAsync();
        }

        // ================================
        // CREATE
        // ================================
        public async Task<EmpleadoInfoDTO> CreateAsync(EmpleadoCreateDTO dto)
        {
            var empleado = new Empleado
            {
                IdUsuario = dto.IdUsuario,
                IdDepartamento = dto.IdDepartamento,
                Cargo = dto.Cargo,
                FechaIngreso = DateTime.UtcNow,
                CreacionUsuario = "sistema",
                ModificacionFecha = DateTime.Now,
                ModificacionUsuario = "sistema"
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);

            return new EmpleadoInfoDTO
            {
                IdEmpleado = empleado.IdEmpleado,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                IdRol = usuario.IdRol,
                Cargo = empleado.Cargo,
                IdDepartamento = empleado.IdDepartamento
            };
        }

        // ================================
        // UPDATE
        // ================================
        public async Task<bool> UpdateAsync(int id, EmpleadoUpdateDTO dto)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            empleado.IdDepartamento = dto.IdDepartamento;
            empleado.Cargo = dto.Cargo;
            empleado.ModificacionFecha = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // ================================
        // DELETE
        // ================================
        public async Task<bool> DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}