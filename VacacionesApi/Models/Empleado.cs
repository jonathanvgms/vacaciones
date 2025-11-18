using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int IdUsuario { get; set; }

    public int IdDepartamento { get; set; }

    public string Cargo { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }

    public DateTime? CreacionFecha { get; set; }

    public string? CreacionUsuario { get; set; }

    public DateTime? ModificacionFecha { get; set; }

    public string? ModificaionUsuario { get; set; }

    public virtual ICollection<Aprobacion> Aprobacions { get; set; } = new List<Aprobacion>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<SaldoVacacione> SaldoVacaciones { get; set; } = new List<SaldoVacacione>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
