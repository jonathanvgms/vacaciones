using VacacionesApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VacacionesContext>(options =>
    options.UseMySql(
        "server=localhost;database=vacaciones_db;user=root;password=root!",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql")
    )
);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ...existing code...

// Obtener todos los ámbitos
app.MapGet("/ambitosferiado", async (VacacionesContext db) =>
    await db.AmbitoFeriados.ToListAsync())
    .WithName("GetAmbitosFeriado")
    .WithOpenApi();

// Obtener un ámbito por ID
app.MapGet("/ambitosferiado/{id}", async (int id, VacacionesContext db) =>
    await db.AmbitoFeriados.FindAsync(id) is AmbitoFeriado ambito
        ? Results.Ok(ambito)
        : Results.NotFound())
    .WithName("GetAmbitoFeriadoById")
    .WithOpenApi();

// Crear un nuevo ámbito
app.MapPost("/ambitosferiado", async (AmbitoFeriado nuevoAmbito, VacacionesContext db) =>
{
    db.AmbitoFeriados.Add(nuevoAmbito);
    await db.SaveChangesAsync();
    return Results.Created($"/ambitosferiado/{nuevoAmbito.IdAmbito}", nuevoAmbito);
})
.WithName("CreateAmbitoFeriado")
.WithOpenApi();

// Actualizar un ámbito existente
app.MapPut("/ambitosferiado/{id}", async (int id, AmbitoFeriado ambitoActualizado, VacacionesContext db) =>
{
    var ambito = await db.AmbitoFeriados.FindAsync(id);
    if (ambito is null) return Results.NotFound();
    ambito.Nombre = ambitoActualizado.Nombre;
    ambito.ModificaionFecha = DateTime.Now;
    ambito.ModificacionUsuario = ambitoActualizado.ModificacionUsuario;
    await db.SaveChangesAsync();
    return Results.Ok(ambito);
})
.WithName("UpdateAmbitoFeriado")
.WithOpenApi();

// Eliminar un ámbito
app.MapDelete("/ambitosferiado/{id}", async (int id, VacacionesContext db) =>
{
    var ambito = await db.AmbitoFeriados.FindAsync(id);
    if (ambito is null) return Results.NotFound();
    db.AmbitoFeriados.Remove(ambito);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("DeleteAmbitoFeriado")
.WithOpenApi();

// ...existing code...
// --- FIN ENDPOINTS AMBITOFERIADO ---

app.Run();
