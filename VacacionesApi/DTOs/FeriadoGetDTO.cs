namespace VacacionesApi;

public class FeriadoGetDTO
{
        public int IdFeriado { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Descripcion { get; set; }
        public string? Pais { get; set; }
        public int IdAmbito { get; set; }
}
