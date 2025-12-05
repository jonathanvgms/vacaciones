using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoService _service;

        public DepartamentoController(DepartamentoService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartamento(int id)
        {
            var d = await _service.GetByIdAsync(id);
            if (d == null) return NotFound();
            return Ok(d);
        }

        // CREATE (recibe DepartamentoCreateDTO)
        [HttpPost]
        public async Task<IActionResult> CreateDepartamento([FromBody] DepartamentoCreateDTO dto)
        {
            if (dto == null) return BadRequest("Datos inválidos.");

            var creado = await _service.CreateAsync(dto);
            return Ok(creado);
        }

        // UPDATE (recibe DepartamentoUpdateDTO)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, [FromBody] DepartamentoUpdateDTO dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            if (ok == null) return NotFound();
            return Ok(ok);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
