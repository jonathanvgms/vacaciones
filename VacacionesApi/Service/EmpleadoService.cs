using System.Collections.Generic;
using System.Threading.Tasks;
using VacacionesApi.Models;
using VacacionesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace VacacionesApi.Services
{
    public class EmpleadoService
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> GetAllEmpleadosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task<Empleado> CreateEmpleadoAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<Empleado> UpdateEmpleadoAsync(Empleado empleado)
        {
            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task DeleteEmpleadoAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }

        internal object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}