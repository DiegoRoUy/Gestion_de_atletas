using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ExcepcionesEntidades.Disciplinas;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioDisciplina : IRepositorioDisciplina
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioDisciplina(LibreriaContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Disciplina item)
        {
            Disciplina discplinaBuscada = FindByNombre(item.Nombre.Valor);
            if (discplinaBuscada == null)
            {
                Contexto.Disciplinas.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new DisciplinaException("La disciplina " + "'" + item.Nombre.Valor + "'" + " ya existe, ingrese otra.");
            }
        }

        public void Delete(int id)
        {
            Disciplina disciplina =FindById(id);
            bool disciplinaConAtleta = DisciplinaTieneAtleta(id);
            if (disciplina !=null && disciplinaConAtleta == false)
            {
                Contexto.Disciplinas.Remove(disciplina);
                Contexto.SaveChanges();
            }
            else if(disciplinaConAtleta == true)
                {
                throw new ConflictException("La disciplina a eliminar tiene asocioado un atleta, no se puede eliminar");
                }
            else
            {
                throw new DisciplinaException("El id de la Disciplina no es correcto");
            }
        }

        public IEnumerable<Disciplina> FindAll()
        {
            return Contexto.Disciplinas.OrderBy(d => d.Nombre).ToList();


        }

        public Disciplina FindById(int id)
        {
            return Contexto.Disciplinas.Find(id);
        }

        public void Update(Disciplina item, int id)
        {
            item.Nombre.Validar();
            Disciplina disciplinaBuscada = FindByNombre(item.Nombre.Valor);

            if (disciplinaBuscada != null && id != disciplinaBuscada.Id)
            {
                throw new ConflictException("Ya existe una disciplina con ese mismo nombre");
            }
            Disciplina disciplina = FindById(id);
            if (disciplina != null)
            {
                disciplina.Nombre = item.Nombre;
                disciplina.FechaIngreso = item.FechaIngreso;
                Contexto.Disciplinas.Update(disciplina);
                Contexto.SaveChanges();
            }
            else
            {
                throw new DisciplinaException("El Id de la disciplina no es correcto");
            }
        }

        public Disciplina FindByNombre(string Nombre)
        {
            return Contexto.Disciplinas.AsEnumerable().SingleOrDefault(d => d.Nombre.Valor == Nombre);
        }

        public bool DisciplinaTieneAtleta(int idDisciplina)
        {
            return Contexto.Disciplinas.Where(d=>d.Id == idDisciplina).Any(d=>d.Atletas.Count()>0);
        }
     
    }
}
