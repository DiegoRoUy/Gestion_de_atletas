using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Auditorias;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Auditorias
{
    public class AltaAuditoria : IAltaAuditoria
    {
        public IRepositorioAuditoria RepoAuditoria { get; set; }

        public AltaAuditoria(IRepositorioAuditoria repoAuditoria)
        {
            RepoAuditoria = repoAuditoria;
        }   

        public void Ejecutar(Auditoria auditoria)
        {
            RepoAuditoria.Add(auditoria);
        }
    }
}
