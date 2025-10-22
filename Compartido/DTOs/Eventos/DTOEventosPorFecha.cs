using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class DTOEventosPorFecha
    {
        public int Id { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string DisciplinaNombre { get; set; }
        public int DisciplinaId { get; set; }
       // public IEnumerable<string> DetalleEvento { get; set; }
    }
}
