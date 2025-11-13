namespace VacacionesApi;

public class EmpleadoDTO
{
        public int IdEmpleado { get; set; }
        public int IdUsuario { get; set; }
        public int IdDepartamento { get; set; }
        public string Cargo { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public DateTime? CreacionFecha { get; set; }
        public string? CreacionUsuario { get; set; }
        public DateTime? ModificacionFecha { get; set; }
        public string? ModificaionUsuario { get; set; }

        // Opcional: mostrar datos relacionados simplificados
        public string? NombreDepartamento { get; set; }
        public string? NombreUsuario { get; set; }
}
