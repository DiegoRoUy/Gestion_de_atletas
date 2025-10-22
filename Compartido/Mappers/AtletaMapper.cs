using Compartido.DTOs.Atletas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades.Atletas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class AtletaMapper
    {

        public static IEnumerable<DTOAtletaListado> //Listado de atletas
            ListAteltasToListDtoAtleta(IEnumerable<Atleta> atletas)
        {
            return atletas.Select(a => new DTOAtletaListado()
            {
                Id = a.Id,
                AtletaNombre = a.NombreAtleta,
                AtletaApellido = a.ApellidoAtleta,
                Sexo = a.Sexo,
                NombrePais = a.Pais.NombrePais,
                DisciplinaAtletas = a.Disciplinas.Select(d => new string(d.Nombre.Valor + " - "))
            });
        }

        public static IEnumerable<DTOAtletaPorDisciplina> 
            ListAtletasXDisciplinaTOListDtoAtleta(IEnumerable<Atleta> atletas)
        {
            return atletas.Select(a => new DTOAtletaPorDisciplina()
            {
                Id = a.Id,
                AtletaNombre = a.NombreAtleta,
                AtletaApellido = a.ApellidoAtleta,
                NombrePais = a.Pais.NombrePais,
            });
        }

        public static DTOAtletaListado AtletaToDTOAtleta(Atleta atleta) //Buscamos un atleta en particular
        {
            if (atleta == null)
            {
                throw new AtletaException("Datos incorrectos");
            }
            return new DTOAtletaListado()
            {
                Id = atleta.Id,
                AtletaNombre = atleta.NombreAtleta,
                AtletaApellido = atleta.ApellidoAtleta,
                Sexo = atleta.Sexo,
                NombrePais = atleta.Pais.NombrePais,
                DisciplinaAtletas = atleta.Disciplinas.Select(d => new string(d.Nombre.Valor))
            };
        }
    }
}
