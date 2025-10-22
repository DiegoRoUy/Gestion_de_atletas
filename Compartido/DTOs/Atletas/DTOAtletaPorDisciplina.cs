using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Atletas
{
    public class DTOAtletaPorDisciplina
    {
        public int Id { get; set; }
        public string AtletaNombre { get; set; }
        public string AtletaApellido { get; set; }
        public string NombrePais { get; set; }
    }
}
