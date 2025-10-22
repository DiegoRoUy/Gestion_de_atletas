using Compartido.DTOs.Eventos;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Eventos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Eventos
{
    public class EventoPorPuntaje : IEventoPorPuntaje
    {

        public IRepositorioEvento RepoEvento {  get; set; }
        public EventoPorPuntaje (IRepositorioEvento repoEvento)
        {
            RepoEvento = repoEvento;
        }

      
        public IEnumerable<DTOEventoBuscado> Ejecutar(decimal puntaje1, decimal puntaje2)
        {
            List<Evento> eventos = RepoEvento.BuscarEventoPorPuntaje(puntaje1, puntaje2).ToList();
            return EventoMapper.ListEventoBuscadoToListDtoEventoBuscado(eventos);
        }
    }
}
