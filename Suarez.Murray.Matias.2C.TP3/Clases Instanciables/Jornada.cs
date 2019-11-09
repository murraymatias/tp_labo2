using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

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

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase,Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static bool operator ==(Jornada j,Alumno a)
        {
            return j.alumnos.Contains(a);
        }

        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

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

        public static bool Guardar(Jornada jornada)
        {
            throw new NotImplementedException();
        }

        public static string Leer()
        {
            throw new NotImplementedException();
        }
    }
}
