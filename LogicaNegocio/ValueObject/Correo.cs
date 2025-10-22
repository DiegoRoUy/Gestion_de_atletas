using LogicaNegocio.ExcepcionesEntidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    [ComplexType]
    public record Correo
    {
       public string Valor {  get; init; }   

        public Correo(string valor)
        {
           Valor= valor;
           Validar();
        }

        private void Validar()
        {
            ValidarEmails();

        }
        public bool ValidarEmails()
        {
            //verifica que no sea vacio, que tenga un solo @ y que tenga un .com
            bool invalido = false;
            bool tieneArroba = false;
            bool tieneCom = false;
            if (string.IsNullOrEmpty(Valor)) 
            { 
                invalido = true; 
            }
            if (!invalido)
            {
                foreach (char c in Valor)
                {
                    if (c == '@')
                    {
                        tieneArroba=true;
                    }
                }
                for (int i = 0; i < Valor.Length - 3; i++)
                {
                    string parte = Valor.Substring(i, 4);
                    if (parte == ".com")
                    {
                        tieneCom = true;
                        break;
                    }
                }
            }
            if (invalido || !tieneArroba || !tieneCom)
            { 
                throw new UsuarioException("El email no es valido"); 
            }
            return invalido;
        }
    }
}
