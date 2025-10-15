using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
using VacacionesApi.Services;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> GetEmpleados()
        {
            var empleados = _empleadoService.GetAllEmpleadosAsync();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public ActionResult<Empleado> GetEmpleado(int id)
        {
            var empleado = _empleadoService. GetEmpleadoByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> CreateEmpleado(Empleado empleado)
        {
           await _empleadoService.CreateEmpleadoAsync(empleado);
            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.IdEmpleado }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest();
            }

            var existingEmpleado = _empleadoService.UpdateEmpleadoAsync;
            if (existingEmpleado == null)
            {
                return NotFound();
            }

            await _empleadoService.UpdateEmpleadoAsync(empleado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = _empleadoService.DeleteEmpleadoAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            await _empleadoService.DeleteEmpleadoAsync(id);
            return NoContent();
        }
    }
}