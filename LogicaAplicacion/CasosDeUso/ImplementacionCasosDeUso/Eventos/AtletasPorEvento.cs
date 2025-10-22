using Compartido.DTOs.Atletas;
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
    public class AtletasPorEvento : IAtletasPorEvento
    {
        public IRepositorioEvento RepoEvento { get; set; }

        public AtletasPorEvento(IRepositorioEvento repoEvento)
        {
            RepoEvento = repoEvento;
        }

        public IEnumerable<DTODetalleEventoList> Ejecutar(int id)
        {
            Evento evento = RepoEvento.FindById(id);
            return EventoMapper.ListAtletasPorIdEventoToDtoDetalleEvento(evento);
                  
              
                      
        }
    }
}
