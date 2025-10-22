using Compartido.DTOs.Disciplinas;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Disciplinas
{
    public class ListadoDisciplinas : IListadoDisciplinas
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }

        public ListadoDisciplinas( IRepositorioDisciplina repositorioDisciplina)
        {
            RepoDisciplina = repositorioDisciplina;
        }
        public IEnumerable<DTODisciplinaListado> Ejecutar()
        {
            List<Disciplina> disciplinas =RepoDisciplina.FindAll().ToList();
            return DisciplinaMapper.ListDisciplinasToListDtoUsuario(disciplinas);
        }
    }
}
