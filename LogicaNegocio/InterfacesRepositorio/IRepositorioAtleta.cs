using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioAtleta : IRepositorio<Atleta>
    {
        Atleta FinByNombreYApellido(string nombre, string apellido);

        IEnumerable<Atleta> AtletasPorDisciplina(int idDisciplina);

    }
}
