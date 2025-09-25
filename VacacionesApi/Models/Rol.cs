using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? CreacionFecha { get; set; }

    public string? CreacionUsuario { get; set; }

    public DateTime? ModificacionFecha { get; set; }

    public string? ModificacionUsuario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
