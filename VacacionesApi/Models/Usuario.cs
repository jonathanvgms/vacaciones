using System;
using System.Collections.Generic;

namespace VacacionesApi.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int IdRol { get; set; }

    public DateTime? CreacionFecha { get; set; }

    public string? CreacionUsuario { get; set; }

    public DateTime? ModificacionFecha { get; set; }

    public string? ModificacionUsuario { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();
}
