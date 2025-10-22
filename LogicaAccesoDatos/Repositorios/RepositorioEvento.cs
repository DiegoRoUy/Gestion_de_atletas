using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Eventos;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEvento : IRepositorioEvento
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioEvento(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Evento item)
        {
            Evento eventoBuscado = FindBynombre(item.NombrePrueba);
            if (eventoBuscado == null)
            {
                Contexto.Eventos.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new EventoException("El nombre de pruebas ingresado ya existe");
            }

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> FindAll()
        {
            return Contexto.Eventos.Include(e => e.Disciplina);
        }

        public Evento FindById(int id)
        {
            return Contexto.Eventos.Where(e => e.Id == id).Include(e => e.DetalleEvento).ThenInclude(d => d.Atleta).SingleOrDefault();
        }

        public void Update(Evento item, int id)
        {
            Contexto.Eventos.Update(item);
            Contexto.SaveChanges();
        }

        public Evento FindBynombre(string nombre)
        {
            return Contexto.Eventos.AsEnumerable().SingleOrDefault(e => e.NombrePrueba == nombre);
        }

        public IEnumerable<Evento> FindByTexto(string nombre)
        {
            return Contexto.Eventos.Where(e => e.NombrePrueba.Contains(nombre)).ToList();
        }

        public IEnumerable<Evento> BuscarEventoPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return Contexto.Eventos.Where(e => e.FechaInicio >= fechaInicio && e.FechaInicio <= fechaFin).Include(e => e.Disciplina);
        }

        public IEnumerable<Evento> BuscarEventoPorIdDisciplina(int idDisciplina)
        {
            return Contexto.Eventos.Where(e=>e.Disciplina.Id==idDisciplina).ToList();
        }

        public void EditarPuntajeAtletaEvento(int idEvento, int IdAtleta, decimal puntaje)
        {
            var detalleEvento = Contexto.DetallesEvento.FirstOrDefault(d => d.EventoId == idEvento && d.AtletaId == IdAtleta);
            if (detalleEvento == null) throw new EventoException("No existe el detalle para el evento y atleta seleccionado");            
            detalleEvento.Puntaje = puntaje;
            Contexto.SaveChanges();

        }
        public DetalleEvento BuscarDetalleEvento(int idEvento, int IdAtleta)
        {
           return Contexto.DetallesEvento.FirstOrDefault(d => d.EventoId == idEvento && d.AtletaId == IdAtleta);

        }

        public IEnumerable<Evento> BuscarEventoPorPuntaje(decimal puntaje1, decimal puntaje2)
        {
            return Contexto.Eventos.Where(e => e.DetalleEvento.Any(d => d.Puntaje >= puntaje1 && d.Puntaje <= puntaje2));
        }
    }
}
