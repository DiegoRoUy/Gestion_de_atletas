using LibreriaWeb.Models.Disciplinas;

namespace LibreriaWeb.Models.Atletas
{
    public class AtletaViewModel
    {
        public int DisciplinaId { get; set; }

        public IEnumerable<DisciplinaListadoViewModel> Disciplinas { get; set; } = new List<DisciplinaListadoViewModel>();


    }
}
