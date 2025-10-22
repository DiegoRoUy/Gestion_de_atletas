using LogicaNegocio.ExcepcionesEntidades.Atletas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{

    //[PrimaryKey(nameof(AtletaId))]
    [PrimaryKey(nameof(AtletaId), nameof(EventoId))]

    public class DetalleEvento
    {
        public int AtletaId { get; set; }
        public Atleta Atleta { get; set; }

        public decimal Puntaje { get; set; }
        public int EventoId { get; set; }

        private DetalleEvento() { }
        public DetalleEvento(decimal puntaje, int eventiId, int ateltaId)
        {
            Puntaje = puntaje;
            EventoId = eventiId;
            AtletaId = ateltaId;
            Validar();
        }
        public DetalleEvento(Atleta atleta, decimal puntaje)
        {
            Atleta = atleta;
            Puntaje = puntaje;
            Validar();
        }

        public void Validar()
        {
            if (Puntaje < 0) throw new AtletaException("El puntaje no puede ser negativo");
          
        }
    }
}
