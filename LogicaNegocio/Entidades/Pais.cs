using LogicaNegocio.ExcepcionesEntidades.Paises;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Pais:IEntity
    {
        public int Id { get; set; }
        public string NombrePais { get; set; }
        public int Habitantes { get; set; }
        public string NombreDelegado { get; set; }
        public int Telefono { get; set; }

        private Pais() { }
        public Pais(int id, string nombrePais, int habitantes, string nombreDelegado, int telefono)
        {
            Id = id;
            NombrePais = nombrePais;
            Habitantes = habitantes;
            NombreDelegado = nombreDelegado;
            Telefono = telefono;
            Validar();
        }
        public void Validar() 
        {
            ValidarId();
            ValidarNombrePais();
            ValidarHabiatantes();
            ValidarNombreDelegado();
            ValidarTelefono();
        }
        public void ValidarId()
        {
            if (Id >= 0)
            {
                throw new PaisException("El id del pais tiene que ser mayor a 0");
            }
        }
        public void ValidarNombrePais()
        {
            if (string.IsNullOrEmpty(NombrePais))
            {
                throw new PaisException("El nombre del pais no puede ser nulo");
            }
        }
        public void ValidarHabiatantes()
        {
            if (Habitantes <= 0)
            {
                throw new PaisException("Los habitantes tienen que ser mayor a 0");
            }
        }
        public void ValidarNombreDelegado()
        {
            if (string.IsNullOrEmpty(NombreDelegado))
            {
                throw new PaisException("El nombre del delgado no puede ser nulo");
            }
        }
        public void ValidarTelefono()
        {
            if(Telefono <= 0)
            {
                throw new PaisException("El telefono no puede estar vacio");
            }
        }

    }
}
