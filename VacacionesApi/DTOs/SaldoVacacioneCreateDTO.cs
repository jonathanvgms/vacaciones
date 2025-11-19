namespace VacacionesApi;

public class SaldoVacacioneCreateDTO
{
    public int IdEmpleado { get; set; }
    public short Anio { get; set; }
    public decimal DiasAsignados { get; set; }
    public decimal DiasTomados { get; set; }
}
