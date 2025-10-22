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
    public class EventoPorNombre : IEventoPorNombre
    {
        public IRepositorioEvento RepoEvento { get; set; }  
        public IRepositorioDisciplina RepoDisciplina { get; set; }
        public EventoPorNombre(IRepositorioEvento repoEvento, IRepositorioDisciplina repoDisciplina)
        {
            RepoEvento = repoEvento;
            RepoDisciplina = repoDisciplina;
        }

        public IEnumerable<DTOEventoBuscado> Ejecutar(string nombre)
        {
            List<Evento> eventos =RepoEvento.FindByTexto(nombre).ToList();           
            return EventoMapper.ListEventoBuscadoToListDtoEventoBuscado(eventos);
        }
    }
}
