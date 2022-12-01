using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebEscuelaMVC.Validation
{
    public class CheckValidNumero : ValidationAttribute
    {

        public CheckValidNumero()
        {

            ErrorMessage = "En número debe ser mayor que 100"; //Esta propiedad la hereda

        }
        public override bool IsValid(object value)
        {
            int numero = (int)value;
            if (numero < 100)
            {
                return false;
            }
            else
            {

                return true;
            }

        }

    }
}