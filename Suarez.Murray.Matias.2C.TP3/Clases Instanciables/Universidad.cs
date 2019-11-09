using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.alumnos.Contains(a);
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g,Profesor p)
        {
            return g.profesores.Contains(p);
        }

        public static bool operator !=(Universidad g,Profesor p)
        {
            return !(g == p);
        }

        public static Profesor operator ==(Universidad g,EClases clase)
        {
            foreach(Profesor profesor in g.profesores)
            {
                if(profesor == clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad g,EClases clase)
        {
            foreach(Profesor profesor in g.profesores)
            {
                if(profesor != clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g,Profesor p)
        {
            if (g != p)
            {
                g.profesores.Add(p);
            }
            return g;
        }

        public static Universidad operator +(Universidad g,Alumno a)
        {
            if(g != a)
            {
                g.Alumnos.Add(a);
                return g;
            }
            throw new AlumnoRepetidoException();
        }

        public static Universidad operator +(Universidad g,EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, (g == clase));
            for (int i = 0; i < g.Alumnos.Count; i++)
            {
                if (g.Alumnos[i] == clase)
                {
                    nuevaJornada.Alumnos.Add(g.Alumnos[i]);
                }
            }
            g.Jornadas.Add(nuevaJornada);

            return g;
        }

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializer = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            return serializer.Guardar(path, uni);
        }

        public Universidad Leer()
        {
            Xml<Universidad> deserializer = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            deserializer.Leer(path, out Universidad universidad);
            return universidad;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Jornada jornada in uni.jornada)
            {
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("<------------------------------------->");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
