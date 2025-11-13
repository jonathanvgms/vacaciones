namespace VacacionesApi;

public class SaldoVacacionesUpdateDTO
{
        public int IdSaldo { get; set; }
        public short Anio { get; set; }
        public decimal DiasAsignados { get; set; }
        public decimal DiasTomados { get; set; }
        public decimal DiasPendientes { get; set; }
}
