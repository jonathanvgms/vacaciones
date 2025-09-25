using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class Notificacion
{
    public int IdNotificacion { get; set; }

    public int IdUsuario { get; set; }

    public string Asunto { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public bool Leido { get; set; }

    public DateTime CreacionFecha { get; set; }

    public string? CreacionUsuario { get; set; }

    public DateTime? ModificacionFecha { get; set; }

    public string? ModificacionUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
