using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class Aprobacion
{
    public int IdAprobacion { get; set; }

    public int IdSolicitud { get; set; }

    public int IdAprobador { get; set; }

    public string? Comentario { get; set; }

    public DateTime CreacionFecha { get; set; }

    public string CreacionUsaurio { get; set; } = null!;

    public DateTime? ModificacionFecha { get; set; }

    public string? ModificacionUsuario { get; set; }

    public virtual Empleado IdAprobadorNavigation { get; set; } = null!;

    public virtual Solicitud IdSolicitudNavigation { get; set; } = null!;
}
