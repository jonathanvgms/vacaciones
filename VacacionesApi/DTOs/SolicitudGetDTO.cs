namespace VacacionesApi;

public class SolicitudGetDTO
{
    public int IdSolicitud { get; set; }
    public string Empleado { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public int DiasSolicitados { get; set; }
}
