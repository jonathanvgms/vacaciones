using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoVacacioneController : ControllerBase
    {
        private readonly SaldoVacacioneService _service;

        public SaldoVacacioneController(SaldoVacacioneService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var saldo = await _service.GetByIdAsync(id);
            if (saldo == null) return NotFound();

            return Ok(saldo);
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(SaldoVacacioneCreateDTO dto)
        {
            var nuevo = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.IdSaldo }, nuevo);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SaldoVacacioneUpdateDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}