namespace VacacionesApi;

public class AprobacionDTO
{
        public int IdAprobacion { get; set; }
        public int IdSolicitud { get; set; }
        public int IdAprobador { get; set; }
        public string? Comentario { get; set; }
        public DateTime CreacionFecha { get; set; }
        public string CreacionUsaurio { get; set; } = null!;
        public DateTime? ModificacionFecha { get; set; }
        public string? ModificacionUsuario { get; set; }

        // Opcional: incluir nombres de las relaciones si querés mostrar info relacionada
        public string? NombreAprobador { get; set; }
        public string? SolicitudResumen { get; set; }
}
