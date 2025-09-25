using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class Feriado
{
    public int IdFeriado { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdAmbito { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? CreacionFecha { get; set; }

    public string? CreacionUsuario { get; set; }

    public DateTime? ModificacionFecha { get; set; }

    public string? ModificacionUsuario { get; set; }

    public string? Pais { get; set; }

    public virtual AmbitoFeriado IdAmbitoNavigation { get; set; } = null!;
}
