using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VacacionesApi.Data;
using VacacionesApi.Models;

namespace VacacionesApi.Services
{
    public class DepartamentoService
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> GetAllDepartamentosAsync()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetDepartamentoByIdAsync(int id)
        {
            return await _context.Departamentos.FindAsync(id);
        }

        public async Task<Departamento> CreateDepartamentoAsync(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
            return departamento;
        }

        public async Task<Departamento> UpdateDepartamentoAsync(Departamento departamento)
        {
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
            return departamento;
        }

        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return false;
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}