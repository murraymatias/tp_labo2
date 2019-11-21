using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador ingresado, en caso de erro devuelve +
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>El operador ingresado o en caso de error: +</returns>
        private static string ValidarOperador(string operador)
        {
            string ret = "+";
            if (operador == "-" || operador == "*" || operador == "/")
            {
                ret = operador;
            }
            return ret;
        }

        /// <summary>
        /// Realiza un operacion matematica entre dos objetos de tipo Numero
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operacion a relizar</param>
        /// <returns></returns>
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
