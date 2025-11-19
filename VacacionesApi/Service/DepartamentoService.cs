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

        // GET ALL -> devuelve DTOs
        public async Task<IEnumerable<DepartamentoGetDTO>> GetAllAsync()
        {
            return await _context.Departamentos
                .Select(d => new DepartamentoGetDTO
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

        // GET BY ID -> DTO
        public async Task<DepartamentoGetDTO?> GetByIdAsync(int id)
        {
            var d = await _context.Departamentos.FindAsync(id);
            if (d == null) return null;

            return new DepartamentoGetDTO
            {
                IdDepartamento = d.IdDepartamento,
                Nombre = d.Nombre,
                CreacionFecha = d.CreacionFecha,
                CreacionUsuario = d.CreacionUsuario,
                ModificacionFecha = d.ModificacionFecha,
                ModificacionUsuario = d.ModificacionUsuario
            };
        }

        // CREATE (recibe DTO de creación)
        public async Task<DepartamentoGetDTO> CreateAsync(DepartamentoCreateDTO dto)
        {
            var entity = new Departamento
            {
                Nombre = dto.Nombre,
                CreacionFecha = DateTime.Now
            };

            _context.Departamentos.Add(entity);
            await _context.SaveChangesAsync();

            return new DepartamentoGetDTO
            {
                IdDepartamento = entity.IdDepartamento,
                Nombre = entity.Nombre,
                CreacionFecha = entity.CreacionFecha
            };
        }

        // UPDATE (recibe DTO de actualización)
        public async Task<bool> UpdateAsync(int id, DepartamentoUpdateDTO dto)
        {
            var existente = await _context.Departamentos.FindAsync(id);
            if (existente == null) return false;

            existente.Nombre = dto.Nombre;
            existente.ModificacionFecha = DateTime.Now;
            existente.ModificacionUsuario = dto.ModificacionUsuario;

            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var existe = await _context.Departamentos.FindAsync(id);
            if (existe == null) return false;

            _context.Departamentos.Remove(existe);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
