using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string ret = "+";
            if (operador == "-" || operador == "*" || operador == "/")
            {
                ret = operador;
            }
            return ret;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double ret = 0;
            string operadorValido = Calculadora.ValidarOperador(operador);
            switch (operadorValido)
            {
                case "+":
                    ret = num1 + num2;
                    break;
                case "-":
                    ret = num1 - num2;
                    break;
                case "*":
                    ret = num1 * num2;
                    break;
                case "/":
                    ret = num1 / num2;
                    break;               
            }
            return ret;
        }
    }
}
