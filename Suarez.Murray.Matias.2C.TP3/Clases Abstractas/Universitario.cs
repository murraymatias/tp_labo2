
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
        public Universitario() { }

        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad) 
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            sb.AppendFormat("LEGAJO: {0}\n", this.legajo);

            return sb.ToString();
        }

        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }

        public static bool operator !=(Universitario pg1,Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            return (this == (Universitario)obj);
        }
        #endregion
    }
}
