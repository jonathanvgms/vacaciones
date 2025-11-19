namespace VacacionesApi;

public class UsuarioUpdateDTO
{
    public string Email { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public int IdRol { get; set; }
    public string? ModificacionUsuario { get; set; }
}
