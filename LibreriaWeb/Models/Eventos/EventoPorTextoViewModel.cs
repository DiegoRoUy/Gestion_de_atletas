using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models.Eventos
{
    public class EventoPorTextoViewModel
    {
        [Display(Name = "Ingrese texto")]
        public string NombrePrueba { get; set; }


    }
}
