namespace VacacionesApi;

public class SolicitudDto
{
        public int IdSolicitud { get; set; }
        public int IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; } // opcional, si querés mostrar el nombre
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int? DiasSolicitados { get; set; }
        public string Estado { get; set; } = null!;
        public string? Motivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreacionUsuario { get; set; } = null!;
}
