using Microsoft.AspNetCore.Mvc;
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

        // ✅ GET: api/Departamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoDTOs>>> GetDepartamentos()
        {
            var departamentos = await _departamentoService.GetAllDepartamentosAsync();
            return Ok(departamentos);
        }

        // ✅ GET: api/Departamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoDTOs>> GetDepartamento(int id)
        {
            var departamento = await _departamentoService.GetDepartamentoByIdAsync(id);
            if (departamento == null)
                return NotFound();

            return Ok(departamento);
        }

        // ✅ POST: api/Departamento
        [HttpPost]
        public async Task<ActionResult<DepartamentoDTOs>> CreateDepartamento([FromBody] DepartamentoCreateDTO dto)
        {
            var nuevoDepartamento = await _departamentoService.CreateDepartamentoAsync(dto);
            return CreatedAtAction(nameof(GetDepartamento), new { id = nuevoDepartamento.IdDepartamento }, nuevoDepartamento);
        }

        // ✅ PUT: api/Departamento/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, [FromBody] DepartamentoUpdateDTO dto)
        {
            if (id != dto.IdDepartamento)
                return BadRequest("El ID de la ruta no coincide con el del cuerpo.");

            var actualizado = await _departamentoService.UpdateDepartamentoAsync(dto);
            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        // ✅ DELETE: api/Departamento/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var eliminado = await _departamentoService.DeleteDepartamentoAsync(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}
