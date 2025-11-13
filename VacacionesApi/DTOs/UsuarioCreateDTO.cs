namespace VacacionesApi;

public class UsuarioCreateDTO
{
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdRol { get; set; }
        public string? CreacionUsuario { get; set; }
}
