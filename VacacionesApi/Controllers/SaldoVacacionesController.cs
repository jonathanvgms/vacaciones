using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoVacacionesController : ControllerBase
    {
        private readonly SaldoVacacionesService _saldoVacacionesService;

        public SaldoVacacionesController(SaldoVacacionesService saldoVacacionesService)
        {
            _saldoVacacionesService = saldoVacacionesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaldoVacacione>>> GetAll()
        {
            var saldos = await _saldoVacacionesService.GetAllAsync();
            return Ok(saldos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaldoVacacione>> GetById(int id)
        {
            var saldo = await _saldoVacacionesService.GetByIdAsync(id);
            if (saldo == null)
            {
                return NotFound();
            }
            return Ok(saldo);
        }

        [HttpPost]
        public async Task<ActionResult<SaldoVacacione>> Create(SaldoVacacione saldoVacaciones)
        {
            var createdSaldo = await _saldoVacacionesService.CreateAsync(saldoVacaciones);
            return CreatedAtAction(nameof(GetById), new { id = createdSaldo }, createdSaldo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SaldoVacacione saldoVacaciones)
        {
            if (id != saldoVacaciones.IdSaldo)
            {
                return BadRequest();
            }

            var existingSaldo = await _saldoVacacionesService.GetByIdAsync(id);
            if (existingSaldo == null)
            {
                return NotFound();
            }

            await _saldoVacacionesService.UpdateAsync(saldoVacaciones);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSaldo = await _saldoVacacionesService.GetByIdAsync(id);
            if (existingSaldo == null)
            {
                return NotFound();
            }

            await _saldoVacacionesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
