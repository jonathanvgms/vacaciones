using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _service;

        public RolController(RolService service)
        {
            _service = service;
        }

        // ============================================
        // GET ALL
        // ============================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolGetDTO>>> GetRoles()
        {
            return Ok(await _service.GetAllRolesAsync());
        }

        // ============================================
        // GET BY ID
        // ============================================
        [HttpGet("{id}")]
        public async Task<ActionResult<RolInfoDTO>> GetRol(int id)
        {
            var rol = await _service.GetRoleByIdAsync(id);
            if (rol == null) return NotFound();

            return Ok(rol);
        }

        // ============================================
        // CREATE
        // ============================================
[HttpPost]
    public async Task<ActionResult<RolGetDTO>> CreateRol([FromBody] RolCreateDTO dto)
{
    var created = await _service.CreateRoleAsync(dto);
    return CreatedAtAction(nameof(GetRol), new { id = created.IdRol }, created);
}


        // ============================================
        // UPDATE
        // ============================================
        [HttpPut("{id}")]
        public async Task<ActionResult<RolGetDTO>> UpdateRol(int id, [FromBody] RolUpdateDTO dto)
        {
            var updated = await _service.UpdateRoleAsync(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // ============================================
        // DELETE
        // ============================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var deleted = await _service.DeleteRoleAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
