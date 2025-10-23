using System.ComponentModel;

namespace LibreriaWeb.Models.Usuarios
{
    public class UsuarioLoginViewModel
    {
        [DisplayName("Email:")]
        public string Email {  get; set; }

        [DisplayName("Contraseña:")]
        public string Password { get; set; }
    }
}
