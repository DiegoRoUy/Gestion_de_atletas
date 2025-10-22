using Compartido.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Roles
{
    public interface IBuscarRol
    {
        DTORolListado Ejecutar(int id);
    }
}
