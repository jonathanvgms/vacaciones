namespace VacacionesApi;

public class SolicitudUpdateDto
{
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int? DiasSolicitados { get; set; }
        public int IdEstado { get; set; }
        public string? Motivo { get; set; }
}
