using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get => this.paquetes;
            set => this.paquetes = value;
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }


        /// <summary>
        /// Finaliza todos los hilos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread thread in this.mockPaquetes)
            {
                if (thread != null && thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }


        /// <summary>
        /// Muestra los datos de todo los envios
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Paquete p in this.paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return sb.ToString();
        }


        /// <summary>
        /// Agrega un paquete no repetido a la lista
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c,Paquete p)
        {
            foreach(Paquete paquete in c.Paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya esta en la lista.");
                }
            }
            c.paquetes.Add(p);
            Thread thread = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(thread);
            thread.Start();
            return c;
        }
    }
}
