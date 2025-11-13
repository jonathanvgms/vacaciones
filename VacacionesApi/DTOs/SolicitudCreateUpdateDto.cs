namespace VacacionesApi;

public class SolicitudCreateUpdateDto
{
        public int IdEmpleado { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int? DiasSolicitados { get; set; }
        public int IdEstado { get; set; }
        public string? Motivo { get; set; }
        public string CreacionUsuario { get; set; } = null!;
}
