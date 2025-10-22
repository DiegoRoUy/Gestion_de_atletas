using Compartido.DTOs.Eventos;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class EventoMapper
    {

        public static IEnumerable<DTOEventoListado>
            ListEventoToListDtoEvento(IEnumerable<Evento> eventos)
        {
            return eventos.Select(e => new DTOEventoListado()
            {
                Id = e.Id,
                NombrePrueba = e.NombrePrueba,
                FechaInicio = e.FechaInicio,
                FechaFin = e.FechaFin,
                DisciplinaNombre = e.Disciplina.Nombre.Valor,
                DisciplinaId = e.DisciplinaId,
            });
        }

        public static IEnumerable<DTOEventoBuscado>
            ListEventoBuscadoToListDtoEventoBuscado(IEnumerable<Evento> eventos)
        {
            return eventos.Select(e => new DTOEventoBuscado()
            {
                Id = e.Id,
                NombrePrueba = e.NombrePrueba,
                FechaInicio = e.FechaInicio,
                FechaFin = e.FechaFin,
                DisciplinaId = e.DisciplinaId,
            });
        }
    

        public static Evento DTOEventoToEvento(DTOEvento dTOEvento)
        {
            if (dTOEvento == null)
            {
                throw new EventoException("Datos incorrectos");
            }
            return new Evento(dTOEvento.DisciplinaId, dTOEvento.NombrePrueba, dTOEvento.FechaInicio, dTOEvento.FechaFin);
        }

        public static IEnumerable<DTOEventosPorFecha>
        ListEventoFechaToListDtoEventoFecha(IEnumerable<Evento> eventos)
        {
            return eventos.Select(e => new DTOEventosPorFecha()
            {
                Id = e.Id,
                NombrePrueba = e.NombrePrueba,
                FechaInicio = e.FechaInicio,
                FechaFin = e.FechaFin,
                DisciplinaNombre = e.Disciplina.Nombre.Valor,
                DisciplinaId = e.DisciplinaId
            });
        }

        public static IEnumerable<DTODetalleEventoList>
            ListAtletasPorIdEventoToDtoDetalleEvento(Evento evento)
        {
            return evento.DetalleEvento.Select(evento => new DTODetalleEventoList()
            {
                IdAtleta = evento.AtletaId,
                NombreAtleta = evento.Atleta.NombreAtleta,
                ApellidoAtleta = evento.Atleta.ApellidoAtleta,
                IdEvento = evento.EventoId,
                Puntaje = evento.Puntaje,
            });
        }

        public static DTODetalleEventoList DetalleEventoToDtoDetalleEvento(DetalleEvento detalle)
        {
            return new DTODetalleEventoList()
            {
                IdAtleta = detalle.AtletaId,
                IdEvento = detalle.EventoId,
                Puntaje = detalle.Puntaje
            };
        }

    }
}
