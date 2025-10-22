using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class LoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public IRepositorioRol RepoRol { get; set; }

        public LoginUsuario(IRepositorioUsuario repoUsuario, IRepositorioRol repoRol)
        {
            RepoUsuario = repoUsuario;
            RepoRol = repoRol;
        }

        public DTOUsuarioIniciarSesion Ejecutar(string email, string password)
        {
            Usuario usuario = RepoUsuario.Login(email, password);
            if (usuario != null)
            {
                Rol rol = RepoRol.FindById(usuario.RolId); //obtenemos el objeto rol para agregarlo al usuario ya que viene null y lo precisamos para el dto(para obtener el string)
                usuario.TipoRol = rol;
            }
            return UsuarioMapper.UsuarioToDTOUsuario(usuario);
        }
    }
}
