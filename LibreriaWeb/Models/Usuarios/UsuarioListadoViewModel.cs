using System.ComponentModel;

namespace LibreriaWeb.Models.Usuarios
{
    public class UsuarioListadoViewModel
    {
        
        public int Id { get; set; }       
        public string Email { get; set; }      
        public int Rol { get; set; }
        [DisplayName("Contraseña")]
        public string Contrasenia { get; set; }
    }
}
