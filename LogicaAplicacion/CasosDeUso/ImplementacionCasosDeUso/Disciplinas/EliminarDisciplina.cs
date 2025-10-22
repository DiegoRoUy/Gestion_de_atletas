using Compartido.DTOs.Disciplinas;
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
    public class EliminarDisciplina : IEliminarDisciplina
    {
        public IRepositorioDisciplina RepoDisciplina { get; set; }
        public IAltaAuditoria AltaAuditoria { get; set; }

        public EliminarDisciplina(IRepositorioDisciplina repoDisciplina, IAltaAuditoria altaAuditoria)
        {
            RepoDisciplina = repoDisciplina;
            AltaAuditoria = altaAuditoria;

        }

        public void Ejecutar(int id, string email)
        {
            RepoDisciplina.Delete(id);
            Auditoria auditoria = new Auditoria("Disciplina", id, "Eliminado", DateTime.Today, email);
            AltaAuditoria.Ejecutar(auditoria);
        }
    }
}
