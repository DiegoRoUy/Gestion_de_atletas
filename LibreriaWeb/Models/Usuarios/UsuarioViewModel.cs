using LibreriaWeb.Models.Roles;
using System.ComponentModel;

namespace LibreriaWeb.Models.Usuarios
{
    public class UsuarioViewModel//Para crear usuarios nuevos
    {
        [DisplayName("Email:")]
        public string Email { get; set; }
        [DisplayName("Contraseña:")]
        public string Contrasenia { get; set; }
        [DisplayName("Rol:")]
        public int Rol { get; set; } 

        public IEnumerable<RolListadoViewModel> Roles { get; set; } =
            new List<RolListadoViewModel>();
    }
}
