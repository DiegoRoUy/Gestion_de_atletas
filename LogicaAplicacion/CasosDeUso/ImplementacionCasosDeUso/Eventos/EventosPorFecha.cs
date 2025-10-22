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
    public class EventosPorFecha : IEventosPorFecha              //Lo utilizamos para filtrar eventos por fecha
    {
        public IRepositorioEvento RepoEvento { get; set; }

        public EventosPorFecha(IRepositorioEvento repoEvento)
        {
            RepoEvento = repoEvento;
        }

        public IEnumerable<DTOEventosPorFecha> Ejecutar(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Evento> eventos = RepoEvento.BuscarEventoPorFecha(fechaInicio, fechaFin).ToList();
            return EventoMapper.ListEventoFechaToListDtoEventoFecha(eventos);
        }

    }
}
