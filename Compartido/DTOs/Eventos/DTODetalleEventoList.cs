using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Eventos
{
    public class DTODetalleEventoList
    {
        public int IdAtleta {  get; set; }
        public string NombreAtleta { get; set; }
        public string ApellidoAtleta { get; set; }
        public int IdEvento { get; set; }            
        public decimal Puntaje {  get; set; }
    }
}
