using Microsoft.AspNetCore.Mvc;
using VacacionesApi.Services;


namespace VacacionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var u = await _service.GetByIdAsync(id);
            if (u == null) return NotFound();
            return Ok(u);
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuarioCreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return Ok(created);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuarioUpdateDTO dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            if (ok == null) return NotFound();
            return Ok(ok);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
