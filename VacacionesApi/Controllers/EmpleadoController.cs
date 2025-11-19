using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
using VacacionesApi.Services;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _service;

        public EmpleadoController(EmpleadoService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoGetDTO>>> GetEmpleados()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoInfoDTO>> GetEmpleado(int id)
        {
            var empleado = await _service.GetByIdAsync(id);
            if (empleado == null) return NotFound();

            return Ok(empleado);
        }

        // CREATE (simple, como Rol)
        [HttpPost]
        public async Task<IActionResult> CreateEmpleado([FromBody] EmpleadoCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos.");

            var created = await _service.CreateAsync(dto);
            return Ok(created);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, [FromBody] EmpleadoUpdateDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}