namespace VacacionesApi;

public class SolicitudUpdateDTO
{
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public string? Motivo { get; set; }
    public int IdEstado { get; set; }
}
