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
          modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AmbitoFeriado>(entity =>
        {
            entity.HasKey(e => e.IdAmbito).HasName("PRIMARY");

            entity.ToTable("ambito_feriado");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IdAmbito).HasColumnName("id_ambito");
            entity.Property(e => e.CreacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.ModificacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificacion_usuario");
            entity.Property(e => e.ModificaionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificaion_fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Aprobacion>(entity =>
        {
            entity.HasKey(e => e.IdAprobacion).HasName("PRIMARY");

            entity.ToTable("aprobacion");

            entity.HasIndex(e => e.IdAprobador, "id_aprobador");

            entity.HasIndex(e => e.IdSolicitud, "id_solicitud");

            entity.Property(e => e.IdAprobacion).HasColumnName("id_aprobacion");
            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .HasColumnName("comentario");
            entity.Property(e => e.CreacionFecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsaurio)
                .HasMaxLength(120)
                .HasColumnName("creacion_usaurio");
            entity.Property(e => e.IdAprobador).HasColumnName("id_aprobador");
            entity.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            entity.Property(e => e.ModificacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificacion_fecha");
            entity.Property(e => e.ModificacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificacion_usuario");

            entity.HasOne(d => d.IdAprobadorNavigation).WithMany(p => p.Aprobacions)
                .HasForeignKey(d => d.IdAprobador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aprobacion_ibfk_2");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.Aprobacions)
                .HasForeignKey(d => d.IdSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aprobacion_ibfk_1");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.CreacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.ModificacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificacion_fecha");
            entity.Property(e => e.ModificacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificacion_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleado");

            entity.HasIndex(e => e.IdDepartamento, "fk_emp_departamento");

            entity.HasIndex(e => e.IdUsuario, "fk_emp_usuario");

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Cargo)
                .HasMaxLength(120)
                .HasColumnName("cargo");
            entity.Property(e => e.CreacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ModificacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificacion_fecha");
            entity.Property(e => e.ModificaionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificaion:usuario");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_emp_departamento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_emp_usuario");
        });

        modelBuilder.Entity<EstadoSolicitud>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.ToTable("estado_solicitud");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.EstadoSolicitudcol)
                .HasMaxLength(45)
                .HasColumnName("estado_solicitudcol");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaUsuario)
                .HasMaxLength(120)
                .HasColumnName("fecha_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Feriado>(entity =>
        {
            entity.HasKey(e => e.IdFeriado).HasName("PRIMARY");

            entity.ToTable("feriado");

            entity.HasIndex(e => e.IdAmbito, "id_ambito");

            entity.HasIndex(e => new { e.Fecha, e.IdAmbito }, "uq_feriado").IsUnique();

            entity.Property(e => e.IdFeriado).HasColumnName("id_feriado");
            entity.Property(e => e.CreacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdAmbito).HasColumnName("id_ambito");
            entity.Property(e => e.ModificacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificacion_fecha");
            entity.Property(e => e.ModificacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificacion_usuario");
            entity.Property(e => e.Pais)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.IdAmbitoNavigation).WithMany(p => p.Feriados)
                .HasForeignKey(d => d.IdAmbito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("feriado_ibfk_1");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PRIMARY");

            entity.ToTable("notificacion");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdNotificacion).HasColumnName("id_notificacion");
            entity.Property(e => e.Asunto)
                .HasMaxLength(120)
                .HasColumnName("asunto");
            entity.Property(e => e.CreacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Leido).HasColumnName("leido");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(500)
                .HasColumnName("mensaje");
            entity.Property(e => e.ModificacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificacion_fecha");
            entity.Property(e => e.ModificacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificacion_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notificacion_ibfk_1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.CreacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.ModificacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificacion_fecha");
            entity.Property(e => e.ModificacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificacion_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<SaldoVacacione>(entity =>
        {
            entity.HasKey(e => e.IdSaldo).HasName("PRIMARY");

            entity.ToTable("saldo_vacaciones");

            entity.HasIndex(e => new { e.IdEmpleado, e.Anio }, "id_empleado").IsUnique();

            entity.Property(e => e.IdSaldo).HasColumnName("id_saldo");
            entity.Property(e => e.Anio)
                .HasColumnType("year")
                .HasColumnName("anio");
            entity.Property(e => e.CreacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.DiasAsignados)
                .HasPrecision(5, 2)
                .HasColumnName("dias_asignados");
            entity.Property(e => e.DiasPendientes)
                .HasPrecision(5, 2)
                .HasColumnName("dias_pendientes");
            entity.Property(e => e.DiasTomados)
                .HasPrecision(5, 2)
                .HasColumnName("dias_tomados");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.ModificacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificacion_fecha");
            entity.Property(e => e.ModificacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificacion_usuario");

        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PRIMARY");

            entity.ToTable("solicitud");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.HasIndex(e => e.IdEstado, "id_estado");

            entity.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.DiasSolicitados).HasColumnName("dias_solicitados");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .HasColumnName("motivo");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitud_ibfk_1");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitud_ibfk_2");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.IdRol, "id_rol");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(80)
                .HasColumnName("apellido");
            entity.Property(e => e.CreacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("creacion_fecha");
            entity.Property(e => e.CreacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("creacion_usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.ModificacionFecha)
                .HasColumnType("datetime")
                .HasColumnName("modificacion_fecha");
            entity.Property(e => e.ModificacionUsuario)
                .HasMaxLength(120)
                .HasColumnName("modificacion_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
