using Compartido.DTOs.Roles;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Roles;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Roles;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Roles
{
    public class BuscarRol : IBuscarRol
    {

        public IRepositorioRol RepoRol {  get; set; }
        public BuscarRol(IRepositorioRol repoRol)
        {
            RepoRol = repoRol;
        }

        public DTORolListado Ejecutar(int id)
        {
            Rol rol = RepoRol.FindById(id);
            DTORolListado dtoRol = null;
            if (rol != null)
            {
                dtoRol = RolMapper.RolTODtoRol(rol);
            }
            else
            {
                throw new RolException("No se encontro rol con ese dato");
            }
            return dtoRol;
        }
    }
}
