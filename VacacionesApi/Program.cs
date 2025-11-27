using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using VacacionesApi.Models;
using VacacionesApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<VacacionesContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 23))
    )
);

builder.Services.AddScoped<AprobacionService>();
builder.Services.AddScoped<DepartamentoService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<FeriadoService>();
builder.Services.AddScoped<NotificacionService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<SaldoVacacioneService>();
builder.Services.AddScoped<SolicitudService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<EstadoSolicitudService>();
builder.Services.AddScoped<AmbitoFeriadoService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
