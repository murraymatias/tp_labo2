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

        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(Enum.GetValues(typeof(Universidad.EClases)).Length));
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public static bool operator ==(Profesor i,Universidad.EClases clases)
        {
            return i.clasesDelDia.Contains(clases);
        }

        public static bool operator !=(Profesor i,Universidad.EClases clases)
        {
            return !(i == clases);
        }
    }
}
