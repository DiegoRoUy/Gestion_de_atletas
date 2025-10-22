using Compartido.DTOs.Atletas;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Atletas;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Atletas
{
    public class ListadoAtletas : IListadoAtletas
    {
        public IRepositorioAtleta RepoAtleta { get; set; }

        public ListadoAtletas(IRepositorioAtleta repositorioAtleta)
        {
            RepoAtleta = repositorioAtleta;
        }

        public IEnumerable<DTOAtletaListado> Ejecutar()
        {
            List<Atleta> atletas = RepoAtleta.FindAll().ToList();
            return AtletaMapper.ListAteltasToListDtoAtleta(atletas);
        }
    }
}