namespace VacacionesApi;

public class EmpleadoCreateDTO
{
        public int IdUsuario { get; set; }
        public int IdDepartamento { get; set; }
        public string Cargo { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }

        // Si se registran automáticamente, podés dejar fuera:
        // CreacionFecha y CreacionUsuario
}
