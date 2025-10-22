using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Auditorias
{
    public interface IAltaAuditoria
    {
        void Ejecutar(Auditoria auditoria);
    }
}
