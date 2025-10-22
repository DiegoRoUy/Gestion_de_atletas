using Compartido.DTOs.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class UsuarioMapper
    {


        public static IEnumerable<DTOUsuarioListado>
            ListUsuarioToListDtoUsuario(IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(u => new DTOUsuarioListado()
            {
                Id = u.Id,
                Email = u.Email.Valor,
                RolId = u.RolId,
                Contrasenia = u.Contrasenia.Valor,

            });
        }
        public static DTOUsuarioIniciarSesion UsuarioToDTOUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new UsuarioException("Datos incorrectos");
            }
            return new DTOUsuarioIniciarSesion()
            {
              
                Email = usuario.Email.Valor,               
                Password = usuario.Contrasenia.Valor,
                Rol=usuario.TipoRol.RolTipo,
            };
        } 
    }
}
