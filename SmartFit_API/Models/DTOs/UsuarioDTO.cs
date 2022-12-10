using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartFit_API.Models.DTOs
{
    public class UsuarioDTO
    {


            public int IdUsuario { get; set; }
            public string Nombre { get; set; } = null!;
            public string Apellidos { get; set; } = null!;
            public string Rol { get; set; }
            public string Direccion { get; set; } = null!;
            public DateTime FechaInicio { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Telefono { get; set; } = null!;
            public string Correo { get; set; } = null!;
            public string Password { get; set; } = null!;




        }
}
