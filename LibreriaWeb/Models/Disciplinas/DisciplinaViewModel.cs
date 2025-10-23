using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models.Disciplinas
{
    public class DisciplinaViewModel // Para agregar Disciplinas nuevas
    {
        [DisplayName("Nombre de Disciplina")]
        public string Nombre { get; set; }

        [DisplayName("Fecha de ingreso a JJOO")]        
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        public string ?Email { get; set; }

    }
}
