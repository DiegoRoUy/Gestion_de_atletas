using Compartido.DTOs.Disciplinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Disciplinas
{
    public interface IDisciplinaPorNombre
    {
        DTODisciplinaListado Ejecutar(string nombre);
    }
}
