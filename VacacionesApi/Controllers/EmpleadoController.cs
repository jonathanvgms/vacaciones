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

        // ✅ GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleadosAsync();

            // Conversión manual a DTO
            var listaDTO = empleados.Select(e => new EmpleadoDTO
            {
                IdEmpleado = e.IdEmpleado,
                IdUsuario = e.IdUsuario,
                IdDepartamento = e.IdDepartamento,
                Cargo = e.Cargo,
                FechaIngreso = e.FechaIngreso
            }).ToList();

            return Ok(listaDTO);
        }

        // ✅ GET: api/Empleado/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleado(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            var dto = new EmpleadoDTO
            {
                IdEmpleado = empleado.IdEmpleado,
                IdUsuario = empleado.IdUsuario,
                IdDepartamento = empleado.IdDepartamento,
                Cargo = empleado.Cargo,
                FechaIngreso = empleado.FechaIngreso
            };

            return Ok(dto);
        }

        // ✅ POST: api/Empleado
        [HttpPost]
        public async Task<ActionResult<EmpleadoDTO>> CreateEmpleado(EmpleadoCreateDTO dto)
        {
            var empleado = new Empleado
            {
                IdUsuario = dto.IdUsuario,
                IdDepartamento = dto.IdDepartamento,
                Cargo = dto.Cargo,
                FechaIngreso = dto.FechaIngreso,
                CreacionFecha = DateTime.Now,
                CreacionUsuario = "sistema"
            };

            var creado = await _empleadoService.CreateEmpleadoAsync(empleado);

            var empleadoDTO = new EmpleadoDTO
            {
                IdEmpleado = creado.IdEmpleado,
                IdUsuario = creado.IdUsuario,
                IdDepartamento = creado.IdDepartamento,
                Cargo = creado.Cargo,
                FechaIngreso = creado.FechaIngreso
            };

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleadoDTO.IdEmpleado }, empleadoDTO);
        }

        // ✅ PUT: api/Empleado/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, EmpleadoUpdateDTO dto)
        {
            if (id != dto.IdEmpleado)
                return BadRequest();

            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);
            if (empleado == null)
                return NotFound();

            // Actualizamos manualmente los campos
            empleado.Cargo = dto.Cargo;
            empleado.IdUsuario = dto.IdUsuario;
            empleado.IdDepartamento = dto.IdDepartamento;
            empleado.FechaIngreso = dto.FechaIngreso;
            empleado.ModificacionFecha = DateTime.Now;
            empleado.ModificaionUsuario = "sistema";

            await _empleadoService.UpdateEmpleadoAsync(empleado);
            return NoContent();
        }

        // ✅ DELETE: api/Empleado/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            await _empleadoService.DeleteEmpleadoAsync(id);
            return NoContent();
        }
    }
}
