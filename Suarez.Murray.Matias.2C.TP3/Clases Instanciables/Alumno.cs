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
        public Alumno() { }

        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO CUENTA: {0}\n", this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Alumno alumno,Universidad.EClases clases)
        {
            return (alumno.claseQueToma == clases && alumno.estadoCuenta != EEstadoCuenta.Deudor);
        }

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
