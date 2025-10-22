using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public Correo Email { get; set; }
        public Password Contrasenia { get; set; }

        [ForeignKey("TipoRol")]
        public int RolId { get; set; }
        public Rol TipoRol { get; set; }
        public string AuditUsu { get; set; }
        public DateTime FechaRegistro { get; set; }

        private Usuario() { }

        public Usuario(string email, string pass)//Iniciar Sesion
        {
            Email = new Correo(email);
            Contrasenia = new Password(pass);
        }
        public Usuario(string email, string pass, Rol tipoRol, string auditUsu, DateTime fechaRegistro)//Crear Usuario Nuevo
        {
            Email = new Correo(email);
            Contrasenia = new Password(pass);
            TipoRol = tipoRol;
            AuditUsu = auditUsu;
            FechaRegistro = DateTime.Now;
        }

    }


}
