using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAtleta : IRepositorioAtleta
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioAtleta(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Atleta item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Atleta FinByNombreYApellido(string nombre, string apellido)
        {
            return Contexto.Atletas.AsEnumerable().SingleOrDefault(a => a.NombreAtleta == nombre && a.ApellidoAtleta == apellido);
        }

        public IEnumerable<Atleta> FindAll()
        {
            return Contexto.Atletas.Include(a => a.Pais).Include(a => a.Disciplinas).OrderBy(a => a.Pais.NombrePais).ThenBy(a => a.ApellidoAtleta).ThenBy(a => a.NombreAtleta).ToList();

        }

        public Atleta FindById(int id)
        {
            return Contexto.Atletas.Include(a => a.Disciplinas).Include(a => a.Pais).SingleOrDefault(a => a.Id == id);
        }

        public void Update(Atleta item, int id)
        {
            Contexto.Atletas.Update(item);
            Contexto.SaveChanges();
        }      

        public IEnumerable<Atleta> AtletasPorDisciplina(int idDisciplina)
        {
            return Contexto.Atletas.Include(p=>p.Pais).Where(a=> a.Disciplinas.Any(d=>d.Id == idDisciplina)).OrderBy(a=>a.NombreAtleta).
                ThenBy(a=>a.ApellidoAtleta);
        }
    }
}
