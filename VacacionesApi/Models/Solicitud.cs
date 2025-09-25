using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int? DiasSolicitados { get; set; }

    public int IdEstado { get; set; }

    public string? Motivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string CreacionUsuario { get; set; } = null!;

    public virtual ICollection<Aprobacion> Aprobacions { get; set; } = new List<Aprobacion>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual EstadoSolicitud IdEstadoNavigation { get; set; } = null!;
}
