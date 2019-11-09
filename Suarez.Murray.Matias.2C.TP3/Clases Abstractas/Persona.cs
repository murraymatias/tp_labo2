using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                if (this.ValidarNombreApellido(value).Length > 0)
                {
                    this.apellido = value;
                }
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(this.ValidarNombreApellido(value).Length > 0)
                {
                    this.nombre = value;
                }
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona() { }

        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni,ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad) { this.DNI = dni; }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad) { this.StringToDNI = dni; }
        #endregion

        #region Metodos
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (!((dato > 0 && dato < 90000000 && nacionalidad == ENacionalidad.Argentino) || (dato > 89999999 && dato < 100000000 && nacionalidad == ENacionalidad.Extranjero)))
            {
                throw new NacionalidadInvalidaException();
            }

            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (!Int32.TryParse(dato, out dni) || dni < 1 || dni > 99999999)
            {
                throw new DniInvalidoException();
            }
         
            return this.ValidarDni(nacionalidad, dni);            
        }

        private string ValidarNombreApellido(string dato)
        {
            if (!dato.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                return "";
            }

            return dato;
        }
        #endregion

        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
