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
    public class PuntajeEvento : IPuntajeEvento
    {
        public IRepositorioEvento RepoEvento { get; set; }

        public PuntajeEvento(IRepositorioEvento repoEvento)
        {
            RepoEvento = repoEvento;

        }
        public void Ejecutar(int idEvento, int idAtleta, decimal puntaje)
        {
            RepoEvento.EditarPuntajeAtletaEvento(idEvento, idAtleta, puntaje);
        }
    }
}
