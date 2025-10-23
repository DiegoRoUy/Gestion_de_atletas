using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models.Eventos
{
    public class EventoFechaViewModel
    {
        [Required]
        [Display(Name = "Fecha de inicio busqueda")]
        [DisplayFormat(DataFormatString="dd/mm/yyyy")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha de fin busqueda")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [DataType(DataType.Date)]
        public DateTime FechaFin {  get; set; }



    }
}
