using Compartido.DTOs.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Disciplinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class DisciplinaMapper
    {
        public static IEnumerable<DTODisciplinaListado> 
            ListDisciplinasToListDtoUsuario(IEnumerable<Disciplina> disciplinas) //Para listado de disciplinas
        {
            return disciplinas.Select(d => new DTODisciplinaListado()
            {
                Id = d.Id,
                Nombre = d.Nombre.Valor,
                FechaInicio = d.FechaIngreso,

            });
        }

        public static Disciplina DTODisciplinaToDisciplina(DTODisciplina dtoDisciplina)
        {
            if (dtoDisciplina == null)
            {
                throw new DisciplinaException("Datos de disciplina incorrectos");
            }
            return new Disciplina(dtoDisciplina.Id,dtoDisciplina.Nombre, dtoDisciplina.FechaInicio);
        }

        public static DTODisciplinaListado DisciplinaToDTODisciplina(Disciplina disciplina)
        {
            if (disciplina == null)
            {
                throw new DisciplinaException("Datos Incorrectos");
            }
            return new DTODisciplinaListado()
            {
                Id= disciplina.Id,
                Nombre = disciplina.Nombre.Valor,
                FechaInicio = disciplina.FechaIngreso,
            };
        }
    }
}
