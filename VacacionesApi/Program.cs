using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VacacionesApi.Services;
using Microsoft.EntityFrameworkCore;
using VacacionesApi.Data;
using VacacionesApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VacacionesContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 23))
            )
);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AprobacionService>();
builder.Services.AddScoped<DepartamentoService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<FeriadoService>();
builder.Services.AddScoped<NotificacionService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<SaldoVacacionesService>();
builder.Services.AddScoped<SolicitudService>();
builder.Services.AddScoped<UsuarioService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();