namespace VacacionesApi;

public class SolicitudInfoDTO
{
    public int IdSolicitud { get; set; }
    public int IdEmpleado { get; set; }
    public string NombreEmpleado { get; set; } = null!;
    public string ApellidoEmpleado { get; set; } = null!;
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public int DiasSolicitados { get; set; }
    public string Estado { get; set; } = null!;
    public string? Motivo { get; set; }
    public DateTime FechaCreacion { get; set; }
}
