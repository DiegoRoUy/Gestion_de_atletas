using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Eventos
{
    public interface IPuntajeEvento
    {
        void Ejecutar(int idEvento, int idAtleta, decimal puntaje);
    }
}
