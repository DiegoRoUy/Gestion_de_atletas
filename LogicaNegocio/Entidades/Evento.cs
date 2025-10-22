using LogicaNegocio.ExcepcionesEntidades.Eventos;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Evento : IEntity
    {
        public int DisciplinaId { get; set; }
        public int Id { get; set; }
        public Disciplina Disciplina { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<DetalleEvento> DetalleEvento { get; set; } = new List<DetalleEvento>();

        private Evento() { }
        public Evento(Disciplina disciplina, string nombrePrueba, DateTime fechaInicio, DateTime fechaFin)
        {
            Disciplina = disciplina;
            NombrePrueba = nombrePrueba;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;

            Validar();
        }

        public Evento(int disciplinaId, string nombrePrueba, DateTime fechaInicio, DateTime fechaFin)
        {
            DisciplinaId = disciplinaId;
            NombrePrueba = nombrePrueba;
            FechaFin = fechaFin;
            FechaInicio = fechaInicio;

            Validar();
        }

        public void Validar()
        {
            ValidarFechaInicio();
            ValidarFechaFin();
            ValidarNombrePrueba();
            
        }


        public void ValidarFechaInicio()
        {
            DateTime _fechaMinima = new DateTime(1900, 01, 01);
            if (FechaInicio < _fechaMinima) throw new EventoException("Ingrese una fecha de inicio valida");
        }
        public void ValidarFechaFin()
        {
            if (FechaInicio > FechaFin) throw new EventoException("La fecha fin del evento tiene que ser posterior a la de inicio");
        }
        public void ValidarNombrePrueba()
        {
            if (string.IsNullOrEmpty(NombrePrueba)) throw new EventoException("Ingrese el nombre de la prueba");
        }
       
    }
}
