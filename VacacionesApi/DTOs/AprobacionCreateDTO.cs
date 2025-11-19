namespace VacacionesApi;

public class AprobacionCreateDTO
{
    public int IdSolicitud { get; set; }
    public int IdAprobador { get; set; }
    public string? Comentario { get; set; }
}
