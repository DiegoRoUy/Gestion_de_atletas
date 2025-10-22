using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        Usuario FindByEmail(string email);
        Usuario Login(string email, string password);

    }
}
