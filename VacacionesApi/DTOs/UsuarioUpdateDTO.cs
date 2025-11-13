namespace VacacionesApi;

public class UsuarioUpdateDTO
{
        public int IdUsuario { get; set; }
        public string Email { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdRol { get; set; }
        public string? ModificacionUsuario { get; set; }
}
