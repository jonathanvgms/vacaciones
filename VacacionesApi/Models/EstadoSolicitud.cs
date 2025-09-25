using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class EstadoSolicitud
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public string? FechaUsuario { get; set; }

    public string? EstadoSolicitudcol { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
