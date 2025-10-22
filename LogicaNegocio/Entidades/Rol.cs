using LogicaNegocio.ExcepcionesEntidades.Roles;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Rol : IEntity
    {
        public int Id { get; set; }
        public string RolTipo { get; set; }
        private Rol() { }
        public Rol(int id, string tipoRol)
        {
            Id = id;
            RolTipo = tipoRol;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(RolTipo))
            {
                throw new RolException("Debe completar el campo Rol");
            }
        }


    }
}
