using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Inicializa la cola de clases de un profesor
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        /// <summary>
        /// Inicializa un profesor
        /// </summary>
        /// <param name="id">Legajo del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">Dni del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        /// <summary>
        /// Agrega una clase aleatoria a la cola.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(Enum.GetValues(typeof(Universidad.EClases)).Length));
        }

        /// <summary>
        /// Devuelde los datos a mostrar de un profesor
        /// </summary>
        /// <returns>Cadena de texto con los datos</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }


        /// <summary>
        /// Devuelve las clases que imparte el profesor
        /// </summary>
        /// <returns>Cadena de texto con las clases imaprtidas</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASES DEL DIA");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {                
                sb.AppendFormat(" {0}", clases.ToString());
            }

            return sb.ToString();
        }


        /// <summary>
        /// Devuelve un string con todo los datos a imprimir de un profesor
        /// </summary>
        /// <returns>Cadena de texto con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Comprueba si un profesor imparte clases de una materia especifica
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clases">Clase a comprobar</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i,Universidad.EClases clases)
        {
            return i.clasesDelDia.Contains(clases);
        }

        /// <summary>
        /// Comprueba si un profesor no imparte clases de una materia especifica
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clases">Clase a comprobar</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i,Universidad.EClases clases)
        {
            return !(i == clases);
        }
    }
}
