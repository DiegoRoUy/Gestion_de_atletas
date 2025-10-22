using LogicaNegocio.ExcepcionesEntidades.Atletas;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Atleta : IEntity
    {
        public int Id { get; set; }
        public string NombreAtleta { get; set; }
        public string ApellidoAtleta { get; set; }
        public string Sexo { get; set; }
        public Pais Pais { get; set; }
        public List<Disciplina> Disciplinas { get; } = new List<Disciplina>();
        private Atleta() {}
        public Atleta (int idAtleta, string nombreAtleta,string apellidoAtelta, string sexo, Pais pais)
        {
            Id = idAtleta;
            NombreAtleta = nombreAtleta;
            ApellidoAtleta = apellidoAtelta;
            Sexo = sexo;
            Pais = pais;
           
            Validar();
        }    

        public void Validar()
        {
            if (string.IsNullOrEmpty(NombreAtleta)) throw new AtletaException("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(ApellidoAtleta)) throw new AtletaException("El apellido no puede ser vacio");
            if (string.IsNullOrEmpty(Sexo)) throw new AtletaException("El sexo no puede ser vacio");
        }
  
    }
}
