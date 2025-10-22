using LogicaNegocio.ExcepcionesEntidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    [ComplexType]
    public record Password
    {

        public string Valor {  get; init; } 

        public Password (string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {         
            if (Valor.Trim().Length <= 6) 
            {
                throw new UsuarioException("La contraseña tiene que tener al menos 6 caracteres");
            }
            if (!ValidarPassword())
            {
                throw new UsuarioException("La contraseña tiene que tener los caracteres especificos");
            }
            

        }
        private bool ValidarPassword()
        {
            bool valida  = false;
            bool mayuscula = false;
            bool minuscula = false;
            bool digito = false;
            bool caracter = false;
            int i = 0;
            while (i< Valor.Length&& !valida)
            {
                if (char.IsLetter(Valor[i])) 
                {
                  if (char.IsLower(Valor[i]))
                  {
                     minuscula=true;;
                  }
                  else
                  {
                    mayuscula = true;
                  }
                }
                else if (char.IsDigit(Valor[i]))
                {
                    digito = true;
                }
                else
                {
                    caracter = true;
                }
                if (minuscula && mayuscula && digito && caracter)
                {
                    valida = true;                    
                }
                i++;                
            }
            return valida;
        }


    }
}
