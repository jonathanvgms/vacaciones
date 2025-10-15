using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Models;
using VacacionesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        // GET: api/usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario usuario)
        {
            var nuevoUsuario = await _usuarioService.CreateUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario }, nuevoUsuario);
        }

        // PUT: api/usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest("El ID del usuario no coincide.");
            }

            await _usuarioService.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        // DELETE: api/usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var eliminado = await _usuarioService.DeleteUsuarioAsync(id);
            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
