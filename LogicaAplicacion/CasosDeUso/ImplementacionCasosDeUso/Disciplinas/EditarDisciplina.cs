using Compartido.DTOs.Disciplinas;
using Compartido.Mappers;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Auditorias;
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
    public class EditarDisciplina : IEditarDisciplina
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }
        public IAltaAuditoria AltaAuditoria { get; set; }

        public EditarDisciplina (IRepositorioDisciplina repoDisciplina, IAltaAuditoria altaAuditoria)
        {
            RepoDisciplina = repoDisciplina;
            AltaAuditoria = altaAuditoria;
        }

        public void Ejecutar(int id, DTODisciplina dTODisciplina)
        {
            Disciplina disciplina= DisciplinaMapper.DTODisciplinaToDisciplina(dTODisciplina);
            if(disciplina!=null)
            {
                RepoDisciplina.Update(disciplina,id);

                Auditoria auditoria = new Auditoria("Disciplina", dTODisciplina.Id, "Editado", DateTime.Today, dTODisciplina.Email);
                AltaAuditoria.Ejecutar(auditoria);
            }

        }
    }
}
