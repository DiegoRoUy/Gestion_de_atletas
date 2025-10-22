using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuarios
{
    public class DTOUsuarioListado
    {
        public int Id { get; set; }
        public string Email {  get; set; }
        public int RolId { get; set; } 

        public string Contrasenia { get; set; }

   
    }
}
