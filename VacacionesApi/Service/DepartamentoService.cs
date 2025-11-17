using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VacacionesApi.Models;

using System;

namespace VacacionesApi.Services
{
    public class DepartamentoService
    {
        private readonly VacacionesContext _context;

        public DepartamentoService(VacacionesContext context)
        {
            _context = context;
        }

        // ✅ Obtener todos los departamentos
public async Task<List<DepartamentoDTOs>> GetAllDepartamentosAsync()
{
    return await _context.Departamentos
        .Select(d => new DepartamentoDTOs
        {
            IdDepartamento = d.IdDepartamento,
            Nombre = d.Nombre,
            CreacionFecha = d.CreacionFecha,
            CreacionUsuario = d.CreacionUsuario,
            ModificacionFecha = d.ModificacionFecha,
            ModificacionUsuario = d.ModificacionUsuario
        })
        .ToListAsync();
}


        // ✅ Obtener uno por ID
        public async Task<DepartamentoDTOs?> GetDepartamentoByIdAsync(int id)
        {
            var d = await _context.Departamentos.FindAsync(id);
            if (d == null)
                return null;

            return new DepartamentoDTOs
            {
                IdDepartamento = d.IdDepartamento,
                Nombre = d.Nombre,
                CreacionFecha = d.CreacionFecha,
                CreacionUsuario = d.CreacionUsuario,
                ModificacionFecha = d.ModificacionFecha,
                ModificacionUsuario = d.ModificacionUsuario
            };
        }

        // ✅ Crear
        public async Task<DepartamentoDTOs> CreateDepartamentoAsync(DepartamentoCreateDTO dto)
        {
            var nuevo = new Departamento
            {
                Nombre = dto.Nombre,
                CreacionFecha = DateTime.Now,
                CreacionUsuario = "sistema"
            };

            _context.Departamentos.Add(nuevo);
            await _context.SaveChangesAsync();

            return new DepartamentoDTOs
            {
                IdDepartamento = nuevo.IdDepartamento,
                Nombre = nuevo.Nombre,
                CreacionFecha = nuevo.CreacionFecha,
                CreacionUsuario = nuevo.CreacionUsuario
            };
        }

        // ✅ Actualizar
        public async Task<bool> UpdateDepartamentoAsync(DepartamentoUpdateDTO dto)
        {
            var departamento = await _context.Departamentos.FindAsync(dto.IdDepartamento);
            if (departamento == null)
                return false;

            departamento.Nombre = dto.Nombre;
            departamento.ModificacionFecha = DateTime.Now;
            departamento.ModificacionUsuario = "sistema";

            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Eliminar
        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
                return false;

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
