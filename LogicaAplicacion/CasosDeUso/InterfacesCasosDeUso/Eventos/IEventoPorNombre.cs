using Compartido.DTOs.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Eventos
{
    public interface IEventoPorNombre
    {
        IEnumerable<DTOEventoBuscado> Ejecutar(string nombre);
    }
}
