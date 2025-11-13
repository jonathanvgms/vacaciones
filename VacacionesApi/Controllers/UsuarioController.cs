using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;


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

        // ✅ GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        // ✅ GET: api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        // ✅ POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> CreateUsuario([FromBody] UsuarioCreateDTO dto)
        {
            var nuevoUsuario = await _usuarioService.CreateUsuarioAsync(dto);
            return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario.IdUsuario }, nuevoUsuario);
        }

        // ✅ PUT: api/usuario/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuarioUpdateDTO dto)
        {
            if (id != dto.IdUsuario)
                return BadRequest("El ID no coincide con el usuario enviado.");

            var actualizado = await _usuarioService.UpdateUsuarioAsync(dto);
            if (actualizado == null)
                return NotFound();
            return NoContent();
        }

        // ✅ DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var eliminado = await _usuarioService.DeleteUsuarioAsync(id);
            if (!eliminado)
            return NotFound();

            return NoContent();
        }
    }
}
