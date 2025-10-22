using Compartido.DTOs.Disciplinas;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Auditorias;
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
    public class AltaDisciplina : IAltaDisciplina
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }

        public IAltaAuditoria AltaAuditoria { get; set; }

        public AltaDisciplina(IRepositorioDisciplina repoDisciplina, IAltaAuditoria altaAuditoria)
        {
            RepoDisciplina = repoDisciplina;
            AltaAuditoria = altaAuditoria;

        }

        public void Ejecutar(DTODisciplina dTODisciplina)
        {

            Disciplina disciplina = DisciplinaMapper.DTODisciplinaToDisciplina(dTODisciplina);
            RepoDisciplina.Add(disciplina);
            dTODisciplina.Id = disciplina.Id;
            Auditoria auditoria = new Auditoria("Disciplina", dTODisciplina.Id, "Creado", DateTime.Today, dTODisciplina.Email);
            AltaAuditoria.Ejecutar(auditoria);
        }
    }
}
