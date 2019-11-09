using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        /// <summary>
        /// Inicializa una variable de tipo jornada, con su lista vacia.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }


        /// <summary>
        /// Inicializa una variable de tipo jornada
        /// </summary>
        /// <param name="clase">Clase de la jornada</param>
        /// <param name="instructor">Prefesor que da la clase</param>
        public Jornada(Universidad.EClases clase,Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Comprueba si un alumno forma parte de la clase
        /// </summary>
        /// <param name="j">Jornada a comprobar</param>
        /// <param name="a">Alumno a comprobar</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            return j.alumnos.Contains(a);
        }


        /// <summary>
        /// Comprueba que un alumno no pertenezca a la clase
        /// </summary>
        /// <param name="j">Jornada a comprobar</param>
        /// <param name="a">Alumno a comprobar</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Agrega un alumno no repetido a la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }

            throw new AlumnoRepetidoException();
        }


        /// <summary>
        /// Devuelve los datos de la jornada como texto
        /// </summary>
        /// <returns>string - los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR ", this.clase.ToString());
            sb.Append(this.instructor.ToString());
            foreach(Alumno alumno in alumnos)
            {
                sb.Append(alumno.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Guarda una jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar en archivo</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Texto.txt";
            return texto.Guardar(path, jornada.ToString());
        }

        /// <summary>
        /// Lee una jornada de un archivo de texto
        /// </summary>
        /// <returns>Texto leido del archivo</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Texto.txt";
            texto.Leer(path, out string datos);
            return datos;
        }
    }
}
