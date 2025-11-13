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
        private readonly RolService _rolService;

        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

        // GET: api/rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolDTO>>> GetRoles()
        {
            var roles = await _rolService.GetAllRolesAsync();
            return Ok(roles);
        }

        // GET: api/rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolDTO>> GetRol(int id)
        {
            var rol = await _rolService.GetRoleByIdAsync(id);
            if (rol == null)
                return NotFound();

            return Ok(rol);
        }

        // POST: api/rol
        [HttpPost]
        public async Task<ActionResult<RolDTO>> CreateRol([FromBody] RolDTO rolDto)
        {
            var createdRol = await _rolService.CreateRoleAsync(rolDto);
            return CreatedAtAction(nameof(GetRol), new { id = createdRol.IdRol }, createdRol);
        }

        // PUT: api/rol/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol(int id, [FromBody] RolDTO rolDto)
        {
            var updated = await _rolService.UpdateRoleAsync(id, rolDto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/rol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var deleted = await _rolService.DeleteRoleAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
