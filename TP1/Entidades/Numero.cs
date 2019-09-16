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

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero))
            {
                this.numero = numero;
            }
            else
            {
                this.numero = numero;
            }
        }

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

        public static string DecimalBinario(double numero)
        {
            return Convert.ToString(Convert.ToInt32(numero), 2);
        }

        public static string DecimalBinario(string numero)
        {
            double resultado;
            if(double.TryParse(numero,out resultado))
            {
                return Numero.DecimalBinario(resultado);
            }
            return "Valor invalido";
        }
        public static double operator -(Numero n1,Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

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
