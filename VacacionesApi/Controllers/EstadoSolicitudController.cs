using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace VacacionesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstadoSolicitudController : ControllerBase
{
    private readonly EstadoSolicitudService _service;

    public EstadoSolicitudController(EstadoSolicitudService service)
    {
        _service = service;
    }

    // GET ALL
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstadoSolicitudGetDTO>>> GetEstados()
    {
        return Ok(await _service.GetAllAsync());
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<EstadoSolicitudGetDTO>> GetEstado(int id)
    {
        var estado = await _service.GetByIdAsync(id);
        if (estado == null) return NotFound();
        return Ok(estado);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> CreateEstado([FromBody] EstadoSolicitudCreateDTO dto)
    {
        if (dto == null) return BadRequest("Datos inválidos.");

        var creado = await _service.CreateAsync(dto);
        return Ok(creado);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEstado(int id, [FromBody] EstadoSolicitudUpdateDTO dto)
    {
        var ok = await _service.UpdateAsync(id, dto);
        if (!ok) return NotFound();
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstado(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}