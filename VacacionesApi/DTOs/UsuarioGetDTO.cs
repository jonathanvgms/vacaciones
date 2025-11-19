namespace VacacionesApi;

public class UsuarioGetDTO
{
        public int IdUsuario { get; set; }
        public string Email { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdRol { get; set; }
        public DateTime? CreacionFecha { get; set; }
        public string? CreacionUsuario { get; set; }
        public DateTime? ModificacionFecha { get; set; }
        public string? ModificacionUsuario { get; set; }
}
