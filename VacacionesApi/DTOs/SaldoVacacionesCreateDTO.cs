namespace VacacionesApi;

public class SaldoVacacionesCreateDTO
{
        public int IdEmpleado { get; set; }
        public short Anio { get; set; }
        public decimal DiasAsignados { get; set; }
        public decimal DiasTomados { get; set; }
        public decimal DiasPendientes { get; set; }
}
