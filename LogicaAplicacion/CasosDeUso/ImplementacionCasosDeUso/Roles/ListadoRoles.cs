using Compartido.DTOs.Roles;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Roles;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Roles
{
    public class ListadoRoles: IListadoRoles
    {
        public IRepositorioRol RepoRoles { get; set; }

        public ListadoRoles(IRepositorioRol repoRoles)
        {
            RepoRoles = repoRoles;
        }

        public IEnumerable<DTORolListado> Ejecutar()
        {
            List<Rol> Roles = RepoRoles.FindAll().ToList();
            return RolMapper.ListaRolToListDtoRol(Roles);   
        }
    }
}
