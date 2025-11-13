using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoVacacionesController : ControllerBase
    {
        private readonly SaldoVacacionesService _service;

        public SaldoVacacionesController(SaldoVacacionesService service)
        {
            _service = service;
        }

        // ✅ GET: api/SaldoVacaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaldoVacacionesDTO>>> GetAll()
        {
            var saldos = await _service.GetAllAsync();
            return Ok(saldos);
        }

        // ✅ GET: api/SaldoVacaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaldoVacacionesDTO>> GetById(int id)
        {
            var saldo = await _service.GetByIdAsync(id);
            if (saldo == null)
                return NotFound();

            return Ok(saldo);
        }

        // ✅ POST: api/SaldoVacaciones
        [HttpPost]
        public async Task<ActionResult<SaldoVacacionesDTO>> Create(SaldoVacacionesCreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdSaldo }, created);
        }

        // ✅ PUT: api/SaldoVacaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SaldoVacacionesUpdateDTO dto)
        {
            if (id != dto.IdSaldo)
                return BadRequest("El ID no coincide.");

            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // ✅ DELETE: api/SaldoVacaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
