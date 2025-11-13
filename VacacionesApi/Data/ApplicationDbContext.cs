using Microsoft.EntityFrameworkCore;
using VacacionesApi.Models;

namespace VacacionesApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Aprobacion> Aprobaciones { get; set; }
        public DbSet<Feriado> Feriados { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<SaldoVacacione> SaldosVacaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aquí puedes configurar las relaciones y restricciones de las entidades
        }
    }
}