using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Disciplina : IEntity
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public List<Atleta> Atletas { get; set; }
        private Disciplina() { }
        public Disciplina(int id, Nombre nombre, DateTime fechaIngreso, List<Atleta> atletas)
        {
            Id = id;
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
            Atletas = atletas;
        }
        public Disciplina(int id, Nombre nombre, DateTime fechaIngreso)
        {
            Id = id;
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
        }

        public Disciplina(int id, string nombreDisciplina, DateTime fechaIngreso)
        {
            Id = id;
            Nombre = new Nombre(nombreDisciplina);
            FechaIngreso = fechaIngreso;
        }
    }
}
