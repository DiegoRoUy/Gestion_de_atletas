using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Auditoria : IEntity
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public int IdEntidad {get; set; }
        public string Operacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Email {  get; set; }

        private Auditoria() { }

        public Auditoria(string entidad, int idEntidad, string operacion, DateTime fecha, string email)
        {
            Entidad = entidad;
            IdEntidad = idEntidad;
            Operacion = operacion;
            Fecha = fecha;
            Email = email;
        }   
    }
}
