using System;
using Microsoft.EntityFrameworkCore;
using VacacionesApi.Models;

namespace VacacionesApi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check if the database has been seeded
                if (context.Departamentos.Any())
                {
                    return;   // DB has been seeded
                }

                context.Departamentos.AddRange(
                    new Departamento { Nombre = "Recursos Humanos", CreacionFecha = DateTime.Now, CreacionUsuario = "admin" },
                    new Departamento { Nombre = "Tecnología", CreacionFecha = DateTime.Now, CreacionUsuario = "admin" }
                );

                context.SaveChanges();
            }
        }
    }
}