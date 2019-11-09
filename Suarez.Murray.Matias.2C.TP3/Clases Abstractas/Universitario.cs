
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa un variable del tipo Universitario con sus valores default
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// Inicializa una variable del tipo universitario
        /// </summary>
        /// <param name="legajo">Lejado del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">Dni del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitaio</param>
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad) 
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Genera cadena de texto con los datos de un universitario
        /// </summary>
        /// <returns>Cadena de texto con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            sb.AppendFormat("LEGAJO: {0}\n", this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Comprueba si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }
        /// <summary>
        /// Comprueba si dos universitarios son distintos
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1,Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Comprueba si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (this == (Universitario)obj);
        }
        #endregion
    }
}
