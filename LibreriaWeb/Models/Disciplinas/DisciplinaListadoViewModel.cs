using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace LibreriaWeb.Models.Disciplinas
{
    public class DisciplinaListadoViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nombre Disciplina")]
        public string Nombre { get; set; }

        [DisplayName("Fecha de inicio Disciplina")]     
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        public string ?Email { get; set; }
    }
}
