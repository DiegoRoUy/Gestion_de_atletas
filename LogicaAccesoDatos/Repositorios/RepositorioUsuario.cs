using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioUsuario(LibreriaContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Usuario item)
        {
            Usuario usuarioBuscado = FindByEmail(item.Email.Valor);
            if (usuarioBuscado == null)
            {
                Contexto.Usuarios.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("El email ingresado ya existe");
            }
        }

        public void Delete(int id)
        {
            Usuario usuario = FindById(id);
            if (usuario != null)
            {
                Contexto.Usuarios.Remove(usuario);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("No existe el email ingresado");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios;
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.Find(id);
        }

        public void Update(Usuario item, int id)
        {
            Usuario usuario = FindById(id);
            if (usuario != null)
            {
                usuario.Email = item.Email;
                usuario.TipoRol = item.TipoRol;
                usuario.Contrasenia = item.Contrasenia;
                Contexto.Usuarios.Update(usuario);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("El usuario no es correcto");
            }
        }

        public Usuario Login(string email, string password)
        {
            Usuario usu = Contexto.Usuarios.AsEnumerable().SingleOrDefault(u => u.Email.Valor == email && u.Contrasenia.Valor == password);
            if (usu != null)
            {
                return usu;
            }
            else
            {
                throw new UsuarioException("El usuario o contraseña no son correctos");
            }
            
        }

        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios.AsEnumerable().SingleOrDefault(u => u.Email.Valor == email);
        }


    }
}
