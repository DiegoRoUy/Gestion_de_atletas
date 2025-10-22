using Compartido.DTOs.Disciplinas;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Disciplinas;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Disciplinas
{
    public class DisciplinaPorNombre : IDisciplinaPorNombre
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }

        public DisciplinaPorNombre(IRepositorioDisciplina repoDisciplina)
        {
            RepoDisciplina = repoDisciplina;
        }

        public DTODisciplinaListado Ejecutar(string nombre)
        {
            Disciplina disciplina = RepoDisciplina.FindByNombre(nombre);
            DTODisciplinaListado dTODisciplina = null;
            if(disciplina != null)
            {
                dTODisciplina= DisciplinaMapper.DisciplinaToDTODisciplina(disciplina);
            }
            else
            {
                throw new DisciplinaException("No se encontro disciplina con ese nombre");
            }

            return dTODisciplina;
        }
    }
}
