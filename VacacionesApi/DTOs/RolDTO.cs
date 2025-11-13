namespace VacacionesApi;

public class RolDTO
{
        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? CreacionFecha { get; set; }
        public string? CreacionUsuario { get; set; }
        public DateTime? ModificacionFecha { get; set; }
        public string? ModificacionUsuario { get; set; }
}
