using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            var roles = await _rolService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _rolService.GetRoleByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> CreateRol(Rol rol)
        {
            var createdRol = await _rolService.CreateRoleAsync(rol);
            return CreatedAtAction(nameof(GetRol), new { id = createdRol.IdRol }, createdRol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol(int id, Rol rol)
        {
            if (id != rol.IdRol)
            {
                return BadRequest();
            }

            var existingRol = await _rolService.GetRoleByIdAsync(id);
            if (existingRol == null)
            {
                return NotFound();
            }

            await _rolService.UpdateRoleAsync(rol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var existingRol = await _rolService.GetRoleByIdAsync(id);
            if (existingRol == null)
            {
                return NotFound();
            }

            await _rolService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
