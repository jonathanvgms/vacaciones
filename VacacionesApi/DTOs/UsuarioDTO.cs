namespace VacacionesApi;

public class UsuarioDTO
{
        public int IdUsuario { get; set; }
        public string Email { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdRol { get; set; }
        public string? RolNombre { get; set; } // opcional, si querés incluir el nombre del rol
        public DateTime? CreacionFecha { get; set; }
        public string? CreacionUsuario { get; set; }
        public DateTime? ModificacionFecha { get; set; }
        public string? ModificacionUsuario { get; set; }
}
