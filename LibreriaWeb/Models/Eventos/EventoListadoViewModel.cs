using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models.Eventos
{
    public class EventoListadoViewModel
    {
        [DisplayName("Identificador Evento")]
        public int Id { get; set; }
        [DisplayName("Nombre de Evento")]
        public string NombrePrueba { get; set; }
        [DisplayName("Fecha inicio Evento")]        
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DisplayName("Fecha fin Evento")]       
        [DataType(DataType.Date)]
        public DateTime FechaFin {get; set; }
        [DisplayName("Disciplina")]
        public int DisciplinaId {  get; set; }
    }
}
