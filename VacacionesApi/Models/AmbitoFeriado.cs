using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class AmbitoFeriado
{
    public int IdAmbito { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? CreacionFecha { get; set; }

    public string? CreacionUsuario { get; set; }

    public DateTime? ModificaionFecha { get; set; }

    public string? ModificacionUsuario { get; set; }

    public virtual ICollection<Feriado> Feriados { get; set; } = new List<Feriado>();
}
