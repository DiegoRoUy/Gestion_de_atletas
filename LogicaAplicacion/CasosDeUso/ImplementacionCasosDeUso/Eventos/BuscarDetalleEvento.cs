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
    public class BuscarDetalleEvento: IBuscarDetalleEvento
    {
        public IRepositorioEvento RepoEvento { get; set; }
        public BuscarDetalleEvento(IRepositorioEvento repoEvento)
        {
            RepoEvento = repoEvento;
        }

        public DTODetalleEventoList Ejecutar(int idEvento, int idAtleta)
        {
           DetalleEvento detalle = RepoEvento.BuscarDetalleEvento(idEvento, idAtleta);
            return EventoMapper.DetalleEventoToDtoDetalleEvento(detalle);
        }
    }
}
