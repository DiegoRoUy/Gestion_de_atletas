using Compartido.DTOs.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Eventos
{
    public interface IEventoPorPuntaje
    {
        IEnumerable<DTOEventoBuscado> Ejecutar(decimal puntaje1, decimal puntaje2);
    }
}
