using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa un alumno con los valores por default
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// Inicializa un alumno
        /// </summary>
        /// <param name="id">Legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Inicializa un alumno
        /// </summary>
        /// <param name="id">Legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve un string con la clase que toma el alumno
        /// </summary>
        /// <returns>clases que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma.ToString();
        }

        /// <summary>
        /// Devuelve los datos del alumno
        /// </summary>
        /// <returns>Datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO CUENTA: {0}\n", this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve los datos del alumno
        /// </summary>
        /// <returns>Datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si un alumno toma una clase determinada
        /// </summary>
        /// <param name="alumno">Alumno a comprobar</param>
        /// <param name="clases">Clase a comprobar</param>
        /// <returns>True si toma esa clase</returns>
        public static bool operator ==(Alumno alumno,Universidad.EClases clases)
        {
            return (alumno.claseQueToma == clases && alumno.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Comprueba si un alumno no toma una clase determinada
        /// </summary>
        /// <param name="alumno">Alumno a comprobar</param>
        /// <param name="clases">Clase a comprobar</param>
        /// <returns>True si toma esa clase</returns>
        public static bool operator !=(Alumno alumno,Universidad.EClases clases)
        {
            return (alumno.claseQueToma != clases);
        }
        #endregion

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
