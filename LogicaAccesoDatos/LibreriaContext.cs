using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<DetalleEvento> DetallesEvento { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }    
       


        public LibreriaContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Property(u => u.Email).
                HasConversion(v => v.Valor, v => new LogicaNegocio.ValueObject.Correo(v));
            

            modelBuilder.Entity<Disciplina>().Property(d => d.Nombre).
                HasConversion(v => v.Valor, v => new LogicaNegocio.ValueObject.Nombre(v));

            base.OnModelCreating(modelBuilder);
        }
    }
}
