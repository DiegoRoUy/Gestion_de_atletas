using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models.Atletas
{
    public class AtletaDisciplinaIdViewModel
    {
        [Required(ErrorMessage = "El ID de la disciplina es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la disciplina debe ser mayor a 0.")]
        [Display(Name = "Disciplina Id")]
        public int DisciplinaId { get; set; }
    }
}
