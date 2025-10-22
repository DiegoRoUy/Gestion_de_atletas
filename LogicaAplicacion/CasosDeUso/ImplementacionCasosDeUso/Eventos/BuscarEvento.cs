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
    public class BuscarEvento : IBuscarEvento //Lo usamos para RF5
    {
        public IRepositorioEvento RepoEvento { get; set; }
        public BuscarEvento(IRepositorioEvento repoEvento)
        {
            RepoEvento = repoEvento;
        }

        public IEnumerable<DTOEventoBuscado> Ejecutar(int id)
        {
            List<Evento> eventos = RepoEvento.BuscarEventoPorIdDisciplina(id).ToList();
            return EventoMapper.ListEventoBuscadoToListDtoEventoBuscado(eventos);
        }
                
    }
}
