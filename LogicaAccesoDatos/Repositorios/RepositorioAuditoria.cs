using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioAuditoria(LibreriaContext contexto)
        { 
            Contexto = contexto;
        }
        public void Add(Auditoria item)
        {
            Contexto.Auditorias.Add(item);
            Contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auditoria> FindAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
