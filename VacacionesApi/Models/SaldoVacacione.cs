using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class SaldoVacacione
{
    public int IdSaldo { get; set; }

    public int IdEmpleado { get; set; }

    public short Anio { get; set; }

    public decimal DiasAsignados { get; set; }

    public decimal DiasTomados { get; set; }

    public decimal DiasPendientes { get; set; }

    public DateTime? CreacionFecha { get; set; }

    public string? CreacionUsuario { get; set; }

    public DateTime? ModificacionFecha { get; set; }

    public string? ModificacionUsuario { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
