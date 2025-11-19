namespace VacacionesApi;

public class SolicitudCreateDTO
{
    public int IdEmpleado { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public string? Motivo { get; set; }
}
