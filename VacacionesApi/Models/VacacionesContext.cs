using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace VacacionesApi.Models;

public partial class VacacionesContext : DbContext
{
    public VacacionesContext()
    {
    }

    public VacacionesContext(DbContextOptions<VacacionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AmbitoFeriado> AmbitoFeriados { get; set; }

    public virtual DbSet<Aprobacion> Aprobaciones { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadoSolicitud> EstadoSolicituds { get; set; }

    public virtual DbSet<Feriado> Feriados { get; set; }

    public virtual DbSet<Notificacion> Notificaciones { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<SaldoVacacione> SaldosVacaciones { get; set; }

    public virtual DbSet<Solicitud> Solicitudes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
