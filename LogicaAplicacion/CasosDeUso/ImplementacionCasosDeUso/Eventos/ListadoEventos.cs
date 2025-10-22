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
    public class ListadoEventos : IListadoEventos
    {
        public IRepositorioEvento RepoEvento { get; set; }

        public ListadoEventos(IRepositorioEvento repoEvento)
        {
            RepoEvento = repoEvento;
        }
        public IEnumerable<DTOEventoListado> Ejecutar()
        {
            List<Evento> eventos = RepoEvento.FindAll().ToList();
            return EventoMapper.ListEventoToListDtoEvento(eventos);
        }
    }
}
