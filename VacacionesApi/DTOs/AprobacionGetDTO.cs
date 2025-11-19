namespace VacacionesApi;

public class AprobacionGetDTO
{
    public int IdAprobacion { get; set; }
    public int IdSolicitud { get; set; }
    public int IdAprobador { get; set; }
    public string? NombreAprobador { get; set; }
    public string? ApellidoAprobador { get; set; }
    public string? Comentario { get; set; }
    public DateTime CreacionFecha { get; set; }
}
