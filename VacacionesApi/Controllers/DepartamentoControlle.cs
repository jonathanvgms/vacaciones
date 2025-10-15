using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
using VacacionesApi.Services;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentoController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            var departamentos = await _departamentoService.GetAllDepartamentosAsync();
            return Ok(departamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _departamentoService.GetDepartamentoByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return Ok(departamento);
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> CreateDepartamento(Departamento departamento)
        {
            var nuevoDepartamento = await _departamentoService.CreateDepartamentoAsync(departamento);
            return CreatedAtAction(nameof(GetDepartamento), new { id = nuevoDepartamento.IdDepartamento }, nuevoDepartamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.IdDepartamento)
            {
                return BadRequest();
            }

            var existingDepartamento = await _departamentoService.GetDepartamentoByIdAsync(id);
            if (existingDepartamento == null)
            {
                return NotFound();
            }

            await _departamentoService.UpdateDepartamentoAsync(departamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var deleted = await _departamentoService.DeleteDepartamentoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}