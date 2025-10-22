using Compartido.DTOs.Atletas;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Atletas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Atletas;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Atletas
{
    public class ListadoAtletasPorDisciplina : IListadoAtletasPorDisciplina
    {
        public IRepositorioAtleta RepoAtleta { get; set; }

        public ListadoAtletasPorDisciplina(IRepositorioAtleta repoAtleta)
        {
            RepoAtleta=repoAtleta;
        }
        public IEnumerable<DTOAtletaPorDisciplina> Ejecutar(int idDisciplina)
        {          
            List<Atleta> ateltas = RepoAtleta.AtletasPorDisciplina(idDisciplina).ToList();
            return AtletaMapper.ListAtletasXDisciplinaTOListDtoAtleta(ateltas);
        }
    }
}
