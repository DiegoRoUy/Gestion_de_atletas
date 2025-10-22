using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Disciplinas;
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
    public class ListadoUsuarios : IListadoUsuarios
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }

        public ListadoUsuarios(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }

        public IEnumerable<DTOUsuarioListado> Ejecutar()
        {
            List<Usuario> usuarios = RepoUsuarios.FindAll().ToList();
            return UsuarioMapper.ListUsuarioToListDtoUsuario(usuarios);
        }
    }
}
