using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public double SetNumero
        {
            set
            {
                this.numero = value;
            }
        }

        /// <summary>
        /// Inicializa el parametro numero en su valor por defecto 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Inicializa el parametro numero en el valor ingresado
        /// </summary>
        /// <param name="numero">Valor del parametro numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Inicializa el parametro numero en el valor ingresado
        /// </summary>
        /// <param name="numero">Valor del parametro numero</param>
        public Numero(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero))
            {
                this.numero = numero;
            }
            else
            {
                this.numero = 0;
            }
        }

        /// <summary>
        /// Convierte un numero en binario a decimal
        /// </summary>
        /// <param name="numero">Numero binario en formato string</param>
        /// <returns>Si se pudo convertir el numero en decimal en formato string, sino Valor Invalido</returns>
        public static string BinarioDecimal(string numero)
        {
            char[] array = numero.ToCharArray();

            Array.Reverse(array);

            int suma = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    if (i == 0)
                    {
                        suma += 1;
                    }
                    else
                    {
                        suma += (int)Math.Pow(2, i);
                    }
                }

                if (array[i] != '0' && array[i] != '1')
                {
                    return "Valor invalido";
                }
            }
            return suma.ToString();
        }
        /// <summary>
        /// Convierte un numero decimal a binario ignorando los valores inferiores a 1
        /// </summary>
        /// <param name="numero">Numero a convertir en binario</param>
        /// <returns>Retorna un string con el numero convertido a binario</returns>
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString(Convert.ToInt32(numero), 2);
        }
        /// <summary>
        /// Convierte un numero decimal a binario ignorando los valores inferiores a 1
        /// </summary>
        /// <param name="numero">Numero a convertir en binario</param>
        /// <returns>Retorna numero convertido a binario en formato string o en caso de error, Valor Invalido</returns>
        public static string DecimalBinario(string numero)
        {
            double resultado;
            if(double.TryParse(numero,out resultado))
            {
                return Numero.DecimalBinario(resultado);
            }
            return "Valor invalido";
        }

        /// <summary>
        /// Resta dos numeros y devuelve el resultado en double
        /// </summary>
        /// <param name="n1">Numero a ser restado</param>
        /// <param name="n2">Numero a restar</param>
        /// <returns>Resultado de la resta en double</returns>
        public static double operator -(Numero n1,Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Suma dos numeros y devuelve le resultado en double
        /// </summary>
        /// <param name="n1">Primer numero a sumar</param>
        /// <param name="n2">Segundo numero a sumar</param>
        /// <returns>Resultado de la suma en double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Multiplia dos numeros y devuelve el resultado en double
        /// </summary>
        /// <param name="n1">Primer numero a multiplicar</param>
        /// <param name="n2">Segundo numero a multiplicar</param>
        /// <returns>Resultado de la multiplicacion en double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos numeros y retorna el resultado
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>El resultado de la division o double.MinValue si el divisor es 0</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// Valida el numero ingresado, en caso de ser invalido devuelve 0
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>El numero ingresado en double o en caso de error 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }
    }
}
