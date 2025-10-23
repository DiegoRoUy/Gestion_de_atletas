using LibreriaWeb.Models.Disciplinas;
using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models.Atletas
{
    public class AtletaListadoViewModel
    {

        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string AtletaNombre { get; set; }
        [Display(Name = "Apellido")]
        public string AtletaApellido { get; set; }

        public string Sexo {  get; set; }
        
        [Display(Name = "Pais")]
        public string NombrePais { get; set; }
        [Display(Name = "Disciplina")]

    
        public int DisciplinaId { get; set; }

        [Display(Name = "Disciplinas")]
        public IEnumerable<string> DisciplinaAtletas { get; set; }
    }
}