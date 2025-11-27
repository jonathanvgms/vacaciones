using System.ComponentModel.DataAnnotations;
namespace VacacionesApi;

public class FeriadoUpdateDTO
{
        public DateOnly Fecha { get; set; }
        public int IdAmbito { get; set; }
        public string? Descripcion { get; set; }
        public string? Pais { get; set; }
}
