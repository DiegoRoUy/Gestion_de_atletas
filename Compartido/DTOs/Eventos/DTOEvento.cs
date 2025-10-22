using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class DTOEvento
    {

        public string NombrePrueba { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DisciplinaId { get; set; }

        public int[] AtletasId { get; set; }
    }
}
