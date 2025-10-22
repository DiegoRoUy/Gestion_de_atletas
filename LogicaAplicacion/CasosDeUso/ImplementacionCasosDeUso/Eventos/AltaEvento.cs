using Compartido.DTOs.Eventos;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Eventos;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Eventos;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Eventos
{
    public class AltaEvento : IAltaEvento
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }
        public IRepositorioEvento RepoEvento { get; set; }
        public IRepositorioAtleta RepoAtleta { get; set; }

        public AltaEvento(IRepositorioDisciplina repoDisciplina, IRepositorioEvento repoEvento, IRepositorioAtleta repoAtleta)
        {
            RepoDisciplina = repoDisciplina;
            RepoEvento = repoEvento;
            RepoAtleta = repoAtleta;
        }

        public void Ejecutar(DTOEvento dTOEvento)
        {
            Disciplina disciplina = RepoDisciplina.FindById(dTOEvento.DisciplinaId);

            List<DetalleEvento> detalleEventos = new List<DetalleEvento>();
            if (dTOEvento.AtletasId != null)
            {
                foreach (int id in dTOEvento.AtletasId)
                {
                    Atleta atleta = RepoAtleta.FindById(id);

                    if (atleta != null)
                    {
                        if (atleta.Disciplinas.Contains(disciplina))
                        {
                            detalleEventos.Add(new DetalleEvento(atleta, 0));
                        }
                        else
                        {
                            throw new EventoException("Revisar los ateltas seleccionados ya que no corresponden a la disciplina");
                        }
                    }
                }
                if (disciplina != null && detalleEventos.Count >= 3)
                {
                    Evento evento = EventoMapper.DTOEventoToEvento(dTOEvento);
                    evento.DetalleEvento = detalleEventos;
                    evento.Disciplina = disciplina;
                    RepoEvento.Add(evento);
                }
                else if (detalleEventos.Count <= 2)
                {
                    throw new EventoException("Debe seleccionar al menos 3 atletas");
                }

            }
            else
            {
                throw new EventoException("No selecciono ningun atleta");
            }
        }
    }
}
