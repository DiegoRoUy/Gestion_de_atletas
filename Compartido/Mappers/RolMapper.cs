using Compartido.DTOs.Roles;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class RolMapper
    {
        public static IEnumerable<DTORolListado> ListaRolToListDtoRol(List<Rol> roles)
        {
            IEnumerable<DTORolListado> DtoRoles = roles.Select(u =>
            new DTORolListado()
            {
                Id = u.Id,
                Rol = u.RolTipo,
            }).ToList();
            return DtoRoles;
        }

        public static DTORolListado RolTODtoRol(Rol rol) 
        {
            if (rol == null)
            {
                throw new RolException("Datos incorrectos");
            }
            return new DTORolListado
            {
                Id=rol.Id,
                Rol=rol.RolTipo,
            };
        }
    }
}
