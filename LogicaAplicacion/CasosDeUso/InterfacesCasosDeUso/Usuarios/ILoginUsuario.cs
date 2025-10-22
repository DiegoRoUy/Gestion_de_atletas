using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface ILoginUsuario
    {
        //DTOUsuarioLogin Ejecutar(string email, string password);
        DTOUsuarioIniciarSesion Ejecutar(string email, string password);
    }
}
