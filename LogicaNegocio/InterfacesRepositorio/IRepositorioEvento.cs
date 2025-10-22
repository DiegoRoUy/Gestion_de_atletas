using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        Evento FindBynombre(string nombre);

        // Lo usamos para editar el puntaje de un atleta
        void EditarPuntajeAtletaEvento(int idEvento, int IdAtleta, decimal puntaje);
        //Lo usamos para buscsar un detalle evento
        public DetalleEvento BuscarDetalleEvento(int idEvento, int IdAtleta);

        IEnumerable<Evento> BuscarEventoPorIdDisciplina(int idDisciplina);

        IEnumerable<Evento> BuscarEventoPorFecha(DateTime fechaInicio, DateTime fechaFin);
        public IEnumerable<Evento> FindByTexto(string texto);
        public IEnumerable<Evento> BuscarEventoPorPuntaje(decimal puntaje1, decimal puntaje2);

    }
}
