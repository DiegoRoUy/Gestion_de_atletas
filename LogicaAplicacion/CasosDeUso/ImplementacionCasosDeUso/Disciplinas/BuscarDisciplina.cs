using Compartido.DTOs.Disciplinas;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Disciplinas;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Disciplinas
{
    public class BuscarDisciplina : IBuscarDisciplina
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }

        public BuscarDisciplina(IRepositorioDisciplina repoDisciplina)
        {
            RepoDisciplina = repoDisciplina;
        }

        public DTODisciplinaListado Ejecutar(int id)
        {
            Disciplina disciplina = RepoDisciplina.FindById(id);
            DTODisciplinaListado dtoDisciplina = null;
            if (disciplina != null)
            {
                dtoDisciplina = DisciplinaMapper.DisciplinaToDTODisciplina(disciplina);
            }
            else
            {
                throw new DisciplinaException("No se encontró una disciplina con ese id");
            }
            return dtoDisciplina;
            
        }


    }
}
